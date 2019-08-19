using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedBoost : PowerUp
{

    public override void Collect()
    {
        StartCoroutine(buffDuration());
        base.Collect();
    }

    IEnumerator buffDuration()
    {
        duration = 10;
        PlayerAttack playerAttack = player.GetComponent<PlayerAttack>();
        playerAttack.Cooldown = 0.3f;
        playerAttack.Speed = 25;
        yield return new WaitForSeconds(duration); 
        playerAttack.Cooldown = 0.5f;
        playerAttack.Speed = 20;
        Debug.Log("acabo");

    }

}

