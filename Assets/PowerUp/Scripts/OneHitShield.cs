using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitShield : PowerUp
{
    public override void Collect()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.IsShielded = true;
        base.Collect();
    }
}
