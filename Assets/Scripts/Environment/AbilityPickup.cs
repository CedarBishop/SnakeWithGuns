using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public Abilities abilityType;
    public Vector3 rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerAbilities>())
        {
            other.GetComponent<PlayerAbilities>().SetAbility(abilityType);
            Destroy(gameObject);
        }
    }
}
