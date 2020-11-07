using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float expandSpeed;
    public bool isAllyShield;

    private void FixedUpdate()
    {
        transform.localScale += Vector3.one * expandSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAllyShield)
        {
            if (other.GetComponent<EnemyProjectile>())
            {
                Destroy(other.gameObject);
            }
        }
        else
        {
            if (other.GetComponent<AllyProjectile>())
            {
                Destroy(other.gameObject);
            }
        }
    }

}
