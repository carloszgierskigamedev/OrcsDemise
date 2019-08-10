using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{

    private int points;
    private HUDPoints hudPoints;


    void Start()
    {
        points = 0;
        hudPoints = GameObject.FindObjectOfType<HUDPoints>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Coin"))
        {


            Destroy(col.gameObject);
            points += 1;
            hudPoints.points += 1;


        }

    }


}
