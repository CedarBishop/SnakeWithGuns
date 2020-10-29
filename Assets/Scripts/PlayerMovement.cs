using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<PlayerSegment> playerSegments = new List<PlayerSegment>();
    public FixedJoystick leftJoystick;
    public float movementSpeed;

    private Vector2 movementDirection = Vector2.right;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (leftJoystick.Direction.magnitude > 0.5f)
        {
            movementDirection = leftJoystick.Direction;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVelocity = new Vector3(movementDirection.x, 0, movementDirection.y) * movementSpeed * Time.fixedDeltaTime;
        print("movement direction: " + movementDirection);
        print("movement velocity: " + movementVelocity);
        rigidbody.velocity = movementVelocity;
    }



}
