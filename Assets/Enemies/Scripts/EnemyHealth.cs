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

    public void DealDamage(float attackDamage)
    {
        currentHealthPoints -= attackDamage;

        if (currentHealthPoints <= 0) 
        {

            Destroy(this.gameObject);

        }

    }

}
