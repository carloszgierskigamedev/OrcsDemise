using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    [SerializeField]
    private GameObject powerUpPrefab; //Tem que usar getters e setters?
    private Rigidbody2D rigidbody2D;
    private int duration;

    public virtual void Collect()
    {



    }

}
