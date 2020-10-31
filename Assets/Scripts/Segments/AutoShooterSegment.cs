using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooterSegment : ShooterSegment
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (initialised == false)
        {
            return;
        }
        FindTarget();
    }


    void FindTarget ()
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
        Shoot(closestEnemy.transform.position);
    }    
}
