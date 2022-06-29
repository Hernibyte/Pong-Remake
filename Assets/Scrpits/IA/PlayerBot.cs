using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBot : MonoBehaviour
{
    [SerializeField]
    private PlayerBotMovement movement = new PlayerBotMovement();

    [HideInInspector]
    public Transform ballTransform;

    private Rigidbody2D rb2D;

    private Vector3 originalPosition;

    public void Reset()
    {
        transform.position = originalPosition;
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;

        movement.Awake(rb2D);
    }

    private void Update()
    {
        if (ballTransform.position.y > transform.position.y) movement.Move(1);
        else
        if (ballTransform.position.y < transform.position.y) movement.Move(-1);
    }
}
