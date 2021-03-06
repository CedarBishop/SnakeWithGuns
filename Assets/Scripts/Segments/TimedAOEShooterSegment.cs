﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAOEShooterSegment : ShooterSegment
{
    public int projectilesFiredPerShot;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (canShoot)
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
        if (projectilesFiredPerShot <= 0)
        {
            return;
        }

        float yRotation = 0.0f;

        for (int i = 0; i < projectilesFiredPerShot; i++)
        {
            yRotation += 360 / projectilesFiredPerShot;
            aimOrigin.transform.rotation = Quaternion.Euler(new Vector3(0.0f, yRotation, 0.0f));
            Instantiate(projectile, firingPoint.position, firingPoint.rotation);
        }
        StartCoroutine("DelayShoot");
    }
}
