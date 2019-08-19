using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set {speed = value;}}

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update() 
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2 (horizontal, vertical);

        direction.Normalize();

        rigidbody2d.velocity = direction * speed;

    }

    void FixedUpdate()
    {



    }

}
