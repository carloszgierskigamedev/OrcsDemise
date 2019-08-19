using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected Rigidbody2D rigidbody2D;
    protected int duration;
    protected GameObject player;

    public virtual void Collect()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player = collider.gameObject;
            Collect();
        }
    }
}
