using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rig2D;

    [SerializeField]
    private BallMovement movement = new BallMovement();

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();

        movement.Awake(rig2D);
        movement.velocity = new Vector3(Random.Range(-2f, -6f), Random.Range(-2f, -6f));
    }

    private void FixedUpdate()
    {
        movement.Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        if (contact.normal.x == 0 && contact.normal.y > 0)
            movement.velocity.y = movement.velocity.y * (-contact.normal.y);
        else if (contact.normal.x == 0 && contact.normal.y < 0)
            movement.velocity.y = movement.velocity.y * contact.normal.y;
        else if (contact.normal.y == 0 && contact.normal.x > 0)
            movement.velocity.x = movement.velocity.x * (-contact.normal.x);
        else if (contact.normal.y == 0 && contact.normal.x < 0)
            movement.velocity.x = movement.velocity.x * contact.normal.x;
        else
            movement.velocity = movement.velocity * (-contact.normal);
    }
}
