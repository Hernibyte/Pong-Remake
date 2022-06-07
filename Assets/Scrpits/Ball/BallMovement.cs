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
        rigidbody.velocity = velocity;
    }
}
