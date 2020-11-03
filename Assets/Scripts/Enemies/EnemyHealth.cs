using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    protected override void Death()
    {
        GameManager.instance.AddToScore(enemy.earnedScore);
        enemy.OnDeath();
        Destroy(this);
    }
}
