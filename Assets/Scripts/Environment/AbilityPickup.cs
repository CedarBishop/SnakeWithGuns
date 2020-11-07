using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public Abilities abilityType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerAbilities>())
        {
            other.GetComponent<PlayerAbilities>().SetAbility(abilityType);
        }
    }
}
