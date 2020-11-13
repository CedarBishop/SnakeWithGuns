﻿using System.Collections;
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
#if UNITY_EDITOR
        Vector3 tempDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (tempDirection.magnitude > 0.5f)
        {
            targetDirection = tempDirection.normalized;
        }
#else
        if (leftJoystick.Direction.magnitude > 0.5f)
        {
            targetDirection = new Vector3(leftJoystick.Direction.x, 0, leftJoystick.Direction.y);
        }
#endif

    }

    private void FixedUpdate()
    {
        currentDirection = Vector3.Slerp(currentDirection, targetDirection, slerpSpeed * Time.fixedDeltaTime);
        Vector3 movementVelocity = currentDirection * movementSpeed * Time.fixedDeltaTime;
        rigidbody.velocity = movementVelocity;
    }

    public void ResetSegmentNumbers ()
    {
        for (int i = 0; i < playerSegments.Count; i++)
        {
            playerSegments[i].ResetSegmentNumber(i);
        }
    }
}
