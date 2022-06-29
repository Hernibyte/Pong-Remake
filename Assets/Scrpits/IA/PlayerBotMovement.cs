using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerBotMovement
{
    public float velocity;
    private Rigidbody2D rigidbody;

    public void Awake(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public void Move(float scalar)
    {
        rigidbody.velocity = new Vector2(0, velocity * scalar);
    }
}
