using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private Rigidbody2D rigidBody;

    //Move the transform using the new direction
    public void Move(Vector2 newDirection)
    {
        Vector2 moveDirection = newDirection * moveSpeed;
        rigidBody.velocity = moveDirection;
    }
}
