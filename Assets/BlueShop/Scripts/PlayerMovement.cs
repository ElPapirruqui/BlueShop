using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    //Move the transform using the new direction
    public void Move(Vector2 newDirection)
    {
        Vector3 moveDirection = new Vector3(newDirection.x, newDirection.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
