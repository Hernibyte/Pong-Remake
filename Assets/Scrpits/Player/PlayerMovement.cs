using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerMovement
{
    public float velocity;
    private Rigidbody2D rigidbody;
    private float y_Position;

    public void Awake(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public void Move(float scalar)
    {
        //y_Position += velocity * scalar;
        rigidbody.velocity = new Vector2(0, velocity * scalar);
        //rigidbody.MovePosition(new Vector2(-9.5f, y_Position));
    }
}
