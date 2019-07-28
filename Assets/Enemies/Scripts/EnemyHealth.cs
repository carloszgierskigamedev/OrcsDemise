﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField]
    private float totalHealthPoints;
    private float currentHealthPoints;

    private SpriteRenderer spriteRenderer;
    private EnemyMovement enemyMovement;
    private Rigidbody2D rigidbody2d;

    private Color originalColor;

    private Coroutine displayCycleCoroutine;

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

            Destroy(this.gameObject);

        }
        else
        {
            if(displayCycleCoroutine != null) StopCoroutine(displayCycleCoroutine);
            displayCycleCoroutine = StartCoroutine(DamageDisplayCycle());

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
