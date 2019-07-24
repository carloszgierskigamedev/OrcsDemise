using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Start()
    {
        Vector3 playerPosition = transform.position;
    }

    void Update()
    {

        Vector3 playerPosition = transform.position;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetMouseButtonDown(0)) 
        {

            Debug.Log(mousePosition);
            Debug.DrawLine(playerPosition, mousePosition, Color.red, 2.5f);

        }
    }
}
