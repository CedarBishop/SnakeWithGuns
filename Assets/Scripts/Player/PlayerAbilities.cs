using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Abilities { None, Shield}

public class PlayerAbilities : MonoBehaviour
{
    private Abilities currentAbility;

    public GameObject shieldPrefab;

    void Start()
    {
        UIManager.instance.abilityButtonPressed += ActivateAbility;
    }

    private void OnDestroy()
    {
        UIManager.instance.abilityButtonPressed -= ActivateAbility;
    }


    void ActivateAbility()
    {
        switch (currentAbility)
        {
            case Abilities.None:
                break;
            case Abilities.Shield:
                ShieldAbility();
                break;
            default:
                break;
        }

        currentAbility = Abilities.None;
    }


    void ShieldAbility ()
    {
        GameObject shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
        Destroy(shield, 2.0f);
    }


    public void SetAbility (Abilities ability)
    {
        currentAbility = ability;
    }
}
