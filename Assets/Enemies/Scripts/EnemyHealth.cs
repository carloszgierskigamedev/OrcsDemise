using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField]
    private float totalHealthPoints;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private GameObject bonePrefab;
    [SerializeField]
    private int coinSpeed;
    private float currentHealthPoints;

    private SpriteRenderer spriteRenderer;
    private EnemyMovement enemyMovement;
    private Rigidbody2D rigidbody2d;

    private Color originalColor;

    private Coroutine displayCycleCoroutine;

    private int coinsToSpawn;

    void Awake()
    {
        currentHealthPoints = totalHealthPoints;    

        enemyMovement = GetComponent<EnemyMovement>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        originalColor = spriteRenderer.color;
    }

    void Update()
    {

    }

    public void DealDamage(float attackDamage)
    {
        currentHealthPoints -= attackDamage;

        if (currentHealthPoints <= 0) 
        {

            SpawnCoins();
            SpawnBones();
            
            Destroy(this.gameObject);
        }
        else
        {
            if(displayCycleCoroutine != null) StopCoroutine(displayCycleCoroutine);
            displayCycleCoroutine = StartCoroutine(DamageDisplayCycle());

        }

    }

    void SpawnCoins()
    {
        coinsToSpawn = Random.Range(0,4);
        
        for (int i = 0; i < coinsToSpawn; i++) 
        {
            GameObject coins = Instantiate(coinPrefab,transform.position, Quaternion.identity);
            Rigidbody2D rigidBody2DCoin = coins.GetComponent<Rigidbody2D>();
            rigidBody2DCoin.AddForce(Random.insideUnitCircle * coinSpeed);
        }
    }

    void SpawnBones()
    {
        int bonesAmount = Random.Range(3, 5);
        
        for (int i = 0; i < bonesAmount; i++) 
        {
            
            Instantiate(bonePrefab, transform.position, Quaternion.identity);
        
        }
    }

    IEnumerator DamageDisplayCycle()
    {

        enemyMovement.enabled = false;
        rigidbody2d.velocity = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            if(i % 2 == 0) spriteRenderer.color = Color.white;
            else spriteRenderer.color = originalColor;

            yield return new WaitForSeconds(.1f);
        }
        
        enemyMovement.enabled = true;
        spriteRenderer.color = originalColor;

        displayCycleCoroutine = null;

    }

}
