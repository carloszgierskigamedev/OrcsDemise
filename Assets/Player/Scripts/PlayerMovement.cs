using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float speed; 


    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update() 
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2 (horizontal, vertical);

        direction.Normalize();

        rigidbody2D.velocity = direction * speed;
;

    }

    void FixedUpdate()
    {



    }
}
