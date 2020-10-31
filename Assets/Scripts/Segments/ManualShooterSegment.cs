using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualShooterSegment : ShooterSegment
{
    public override void Init()
    {
        base.Init();
        PlayerShoot.onPlayerShoot += OnPlayerShoot;
    }

    private void OnDestroy()
    {
        PlayerShoot.onPlayerShoot -= OnPlayerShoot;
    }

    void OnPlayerShoot (Vector3 direction)
    {
        Shoot(direction + transform.position);
    }
}
