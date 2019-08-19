using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PowerUp
{
    [SerializeField]
    protected int healedHP;

    public override void Collect()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth.CurrentHealthPoints < 100)
        {
            if (playerHealth.CurrentHealthPoints + healedHP > 100)
            {
                playerHealth.CurrentHealthPoints = 100;
            } 
            else 
            {
                playerHealth.CurrentHealthPoints += healedHP;
            }
        }
        base.Collect();
    }

}
