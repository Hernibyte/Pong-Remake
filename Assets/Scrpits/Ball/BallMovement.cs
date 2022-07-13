using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BallMovement
{
    public Vector2 velocity;

    private Rigidbody2D rigidbody;

    public void Awake(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public void Move()
    {
        rigidbody.AddForce(velocity, ForceMode2D.Impulse);
    }

    public void Stop()
    {
        rigidbody.velocity = Vector2.zero;
    }

    public void Clamp()
    {
        if (rigidbody.velocity.x > 10)
            rigidbody.velocity = new Vector2(10, rigidbody.velocity.y);
        if (rigidbody.velocity.x < -10)
            rigidbody.velocity = new Vector2(-10, rigidbody.velocity.y);
        if (rigidbody.velocity.y > 10)
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 10);
        if (rigidbody.velocity.y < -10)
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -10);
    }
}
