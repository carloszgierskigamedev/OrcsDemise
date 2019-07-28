using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private float speed; 
    public float Speed { get { return speed; } }

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
    // eu tentando fazer pegar as coins mas não consegui passar disso, pensei em talvez colocar um script nas coins chamado CoinCatcher ou algo do tipo. @_@
    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     CoinPrefab coinPrefab = col.gameObject.GetComponent<CoinPrefab>();

    //     if (col.gameObject.name=="coinPrefab")
    //     {

    //         Debug.Log("coin");

    //     }

    // }

}
