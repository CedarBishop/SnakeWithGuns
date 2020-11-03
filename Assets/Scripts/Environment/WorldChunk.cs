using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    public float distanceFromCentre;

    public WorldChunk[] neighbourChunks; // 0. top, 1.topright, 2.right, 3. bottomright, 4. bottom, 5. bottomleft, 6. left, 7. topleft

    private PlayerMovement player;

    private bool initialised;

    public void Init ()
    {
        neighbourChunks = new WorldChunk[8];
        initialised = true;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (initialised == false)
        {
            Init();
        }
    }

    private void Update()
    {
        //// Left
        CheckIfSpawnChunk(6, 2, player.transform.position.x, transform.position.x, true, transform.position + (Vector3.left * 50));
        // Right
        CheckIfSpawnChunk(2, 6, player.transform.position.x, transform.position.x, false, transform.position + (Vector3.right * 50));
        // Top
        CheckIfSpawnChunk(0, 4, player.transform.position.z, transform.position.z, false,  transform.position + (Vector3.forward * 50));
        // Bottom
        CheckIfSpawnChunk(4, 0, player.transform.position.z, transform.position.z, true, transform.position + (Vector3.back * 50));
    }

    void CheckIfSpawnChunk(int spawnIndex, int destroyIndex, float valueA, float valueB, bool isNegativeComparison, Vector3 positionToSpawn)
    {
        bool value = false;
        if (isNegativeComparison)
        {
            if ((valueB - valueA) < -distanceFromCentre)
            {
                value = true;
            }
        }
        else
        {
            if ((valueA - valueB) > distanceFromCentre)
            {
                value = true;
            }
        }
        if (value)
        {
            if (neighbourChunks[spawnIndex] == null)
            {
                neighbourChunks[spawnIndex] = Instantiate(LevelManager.instance.worldChunk, positionToSpawn, Quaternion.identity);
                neighbourChunks[spawnIndex].Init();
               neighbourChunks[spawnIndex].neighbourChunks[destroyIndex] = this;
            }
            if (neighbourChunks[destroyIndex] != null)
            {
                Destroy(neighbourChunks[destroyIndex].gameObject);
                neighbourChunks[destroyIndex] = null;
            }
        }
    }

}
