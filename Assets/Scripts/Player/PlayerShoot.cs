﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static event Action<Vector3> onPlayerShoot;
    public FixedJoystick rightJoystick;
    public Transform aimOrigin;
    public Transform firingPoint;
    public Projectile projectilePrefab;
    public float shootDelay;

    private bool isShooting;
    private bool canShoot;
    
    void Start()
    {
        canShoot = true;   
    }

    void Update()
    {
        if (rightJoystick.Direction.magnitude > 0.5f)
        {
            Vector3 aimTarget = transform.position + new Vector3(rightJoystick.Direction.x, 0.0f, rightJoystick.Direction.y);
            transform.forward = (aimTarget - transform.position).normalized;
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }


    private void FixedUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        if (isShooting == false)
        {
            return;
        }
        if (canShoot == false)
        {
            return;
        }

        Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        if (onPlayerShoot != null)
        {
            onPlayerShoot(aimOrigin.forward);
        }
        StartCoroutine("DelayShoot");
    }


    IEnumerator DelayShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

}