using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSegment : PlayerSegment
{
    public Transform aimOrigin;
    public Transform firingPoint;
    public AllyProjectile projectile;
    public float shootDelay;
    public float attackRange;

    protected bool canShoot;
    public override void Init()
    {
        base.Init();
        StartCoroutine("DelayShoot");
    }

    protected IEnumerator DelayShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    protected void Shoot (Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        aimOrigin.transform.forward = direction;
        Instantiate(projectile, firingPoint.position, firingPoint.rotation);
        StartCoroutine("DelayShoot");
    }
}
