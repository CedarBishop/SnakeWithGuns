using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyProjectile : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>())
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
