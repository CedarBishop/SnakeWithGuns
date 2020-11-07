using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public AbilityPickup[] abilityPickupPrefabs;
    public float maxDistanceFromPlayer;
    public float minDistanceFromPlayer;
    public float spawnDelay;

    private PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        StartCoroutine("SpawnPickups");
    }

    IEnumerator SpawnPickups()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            float xDistance = Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
            float zDistance = Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
            xDistance *= (Random.Range(0, 2) > 0) ? 1 : -1;
            zDistance *= (Random.Range(0, 2) > 0) ? 1 : -1;

            Vector3 randPostion = new Vector3(player.transform.position.x + xDistance,
                player.transform.position.y,
                player.transform.position.z + zDistance);

            if (abilityPickupPrefabs != null)
            {
                if (abilityPickupPrefabs.Length == 1)
                {
                    Instantiate(abilityPickupPrefabs[0], randPostion, Quaternion.identity);
                }
                else if (abilityPickupPrefabs.Length > 1)
                {
                    Instantiate(abilityPickupPrefabs[Random.Range(0, abilityPickupPrefabs.Length)], randPostion, Quaternion.identity);
                }
            }
        }
    }
}
