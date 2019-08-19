using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedIncrease : PowerUp
{

    public override void Collect()
    {
        StartCoroutine(buffDuration());
        base.Collect();
    }

    IEnumerator buffDuration()
    {
        duration = 10;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.Speed = 12;
        yield return new WaitForSeconds(duration); 
        playerMovement.Speed = 8;

    }

}
