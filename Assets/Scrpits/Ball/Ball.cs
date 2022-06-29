using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CustomEvents
{
    public class GoalType_e : UnityEvent<MyGoals.ETypeGoal> { }
}

namespace MyBall
{
    public enum StartDirection
    {
        Left,
        Right
    }
}

public class Ball : MonoBehaviour
{
    public CustomEvents.GoalType_e triggerWithGoal = new CustomEvents.GoalType_e();

    private BallMovement movement = new BallMovement();

    Rigidbody2D rig2D;

    Vector2 originalPosition;

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();

        originalPosition = transform.position;

        movement.Awake(rig2D);
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

        movement.velocity.x *= Random.Range(0.9f, 1.2f);
        movement.velocity.y *= Random.Range(0.9f, 1.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MyGoals.IGoal goal;
        if (collision.gameObject.TryGetComponent<MyGoals.IGoal>(out goal))
        {
            triggerWithGoal.Invoke(goal.GetGoal());
        }
    }

    public void Reset()
    {
        transform.position = originalPosition;
        movement.velocity = Vector2.zero;
    }

    public void SetVelocity(MyBall.StartDirection startDirection)
    {
        switch (startDirection)
        {
            case MyBall.StartDirection.Left:
                movement.velocity = new Vector3(Random.Range(-3f, -6f), Random.Range(-6f, 6f));
                break;
            case MyBall.StartDirection.Right:
                movement.velocity = new Vector3(Random.Range(3f, 6f), Random.Range(-6f, 6f));
                break;
        }
    }
}
