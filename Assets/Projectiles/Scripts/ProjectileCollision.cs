using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    [SerializeField]
    private float attackDamage;

    void Start()
    {

    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(attackDamage);
        }

        Destroy(this.gameObject);

    }

}