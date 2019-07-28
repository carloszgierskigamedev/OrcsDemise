using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField]
    private GameObject attackPrefab;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float cooldown = 0.5f;
    private bool hasShoot;

    void Awake()
    {
        hasShoot = false;
    }

    void Update()
    {

        Vector3 playerPosition = transform.position;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetMouseButtonDown(0)) 
        {

            if (hasShoot == false) 
            {

                Debug.DrawLine(playerPosition, mousePosition, Color.red, 2.5f);

                Vector2 direction = mousePosition - playerPosition;

                direction.Normalize();

                Vector2 attackBornLocation = (Vector2)playerPosition + (direction * 1.2f);

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                Quaternion rotation = Quaternion.Euler(0f,0f, angle);

                GameObject attack = Instantiate(attackPrefab, attackBornLocation, rotation);

                Rigidbody2D rigidbody2d = attack.GetComponent<Rigidbody2D>();

                rigidbody2d.velocity = direction * speed;

                StartCoroutine(AttackCooldown());
                
            }

        }

    }

    IEnumerator AttackCooldown() 
    {
        hasShoot = true;

        yield return new WaitForSeconds(cooldown);

        hasShoot = false;
    }

}
