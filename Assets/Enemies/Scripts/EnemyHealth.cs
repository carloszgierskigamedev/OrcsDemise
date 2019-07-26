using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{



    [SerializeField]
    private float totalHealthPoints;
    private float currentHealthPoints;


    void Awake()
    {
        currentHealthPoints = totalHealthPoints;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D (Collision2D col) 
    {

        if (col.gameObject.tag.Equals("Projectile"))
        {

            currentHealthPoints -= 20;

            if (currentHealthPoints <= 0) 
            {

                Destroy(this.gameObject);

            }

        }

    }


}
