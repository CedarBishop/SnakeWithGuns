using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyPrefabs;
    public float maxDistanceFromPlayer;
    public float minDistanceFromPlayer;
    public float spawnDelay;
    
    private PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            float xDistance = Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
            float zDistance = Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
            xDistance *= (Random.Range(0, 2) > 0)? 1 : -1;
            zDistance *= (Random.Range(0, 2) > 0) ? 1 : -1;

            Vector3 randPostion = new Vector3(player.transform.position.x + xDistance,
                player.transform.position.y,
                player.transform.position.z + zDistance);

            if (enemyPrefabs != null)
            {
                if (enemyPrefabs.Length == 1)
                {
                    Instantiate(enemyPrefabs[0], randPostion, Quaternion.identity);
                }
                else if (enemyPrefabs.Length > 1)
                {
                    Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], randPostion, Quaternion.identity);
                }
            }            
        }
    }


}
