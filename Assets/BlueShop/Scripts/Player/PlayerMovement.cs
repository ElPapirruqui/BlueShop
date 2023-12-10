using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private Rigidbody2D rigidBody;
    private Vector2 moveDirection;

    //Move the transform using the new direction
    public void Move(Vector2 newDirection)
    {
        moveDirection = newDirection * moveSpeed;
        rigidBody.velocity = moveDirection;
    }

    public bool IsMoving()
    {
        return moveDirection != Vector2.zero;
    }
}
