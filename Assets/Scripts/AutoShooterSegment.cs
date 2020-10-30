using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooterSegment : PlayerSegment
{
    public Transform aimOrigin;
    public Transform firingPoint;
    public AllyProjectile projectile;
    public float shootDelay;
    public float attackRange;

    private bool canShoot;
    public override void Init()
    {
        base.Init();
        StartCoroutine("DelayShoot");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Shoot();
    }


    void Shoot ()
    {
        if (canShoot == false)
        {
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
        List<Enemy> enemies = new List<Enemy>();
        foreach (var item in colliders)
        {
            if (item.GetComponent<Enemy>())
            {
                enemies.Add(item.GetComponent<Enemy>());
            }
        }

        if (enemies.Count == 0)
        {
            return;
        }
        Enemy closestEnemy = enemies[0];
        float distanceToClosestEnemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
        foreach (Enemy currentEnemy in enemies)
        {
            float distanceToCurrentEnemy = Vector3.Distance(transform.position, currentEnemy.transform.position);
            if (distanceToCurrentEnemy < distanceToClosestEnemy)
            {
                closestEnemy = currentEnemy;
                distanceToClosestEnemy = distanceToCurrentEnemy;
            }
        }

        Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
        aimOrigin.transform.forward = direction;
        Instantiate(projectile, firingPoint.position, firingPoint.rotation);
        StartCoroutine("DelayShoot");
    }

    IEnumerator DelayShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
