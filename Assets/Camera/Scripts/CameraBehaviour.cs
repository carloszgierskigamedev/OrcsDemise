using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private float snapSpeed = 7f;

    private Vector3 TargetPosition
    {
        get
        {
            Vector3 pos = playerMovement.transform.position;
            pos.z = -10f;
            return pos;
        }
    }

    void Awake()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        snapSpeed = playerMovement.Speed * .9f;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, snapSpeed);
    }

}
