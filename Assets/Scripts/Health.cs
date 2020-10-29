using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death ()
    {
    }
}
