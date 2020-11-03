using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<PlayerSegment> playerSegments = new List<PlayerSegment>();
    private FixedJoystick leftJoystick;
    public float movementSpeed;
    public float slerpSpeed;

    private Vector3 targetDirection = Vector3.right;
    private Vector3 currentDirection = Vector3.right;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        leftJoystick = UIManager.instance.leftJoystick;
    }

    private void Update()
    {
        if (leftJoystick.Direction.magnitude > 0.5f)
        {
            targetDirection = new Vector3(leftJoystick.Direction.x, 0, leftJoystick.Direction.y);
        }
    }

    private void FixedUpdate()
    {
        currentDirection = Vector3.Slerp(currentDirection, targetDirection, slerpSpeed * Time.fixedDeltaTime);
        Vector3 movementVelocity = currentDirection * movementSpeed * Time.fixedDeltaTime;
        rigidbody.velocity = movementVelocity;
    }
}
