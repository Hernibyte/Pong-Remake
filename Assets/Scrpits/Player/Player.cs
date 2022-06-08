using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig2D;

    [SerializeField]
    PlayerMovement movement = new PlayerMovement();

    [SerializeField]
    PlayerInput input = new PlayerInput();

    Vector2 originalPostion;

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();

        movement.Awake(rig2D);

        originalPostion = transform.position;
    }

    private void FixedUpdate()
    {
        movement.Move(input.ProcessInput().movement);
    }

    public void Reset()
    {
        transform.position = originalPostion;
    }
}
