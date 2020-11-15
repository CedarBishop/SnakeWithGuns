using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    public List<PlayerSegment> playerSegments = new List<PlayerSegment>();
    public int maxSegments;

    public float speed;
    public float fireRate;
    public float bulletsSpawned;


    public void ResetSegmentNumbers()
    {
        for (int i = 0; i < playerSegments.Count; i++)
        {
            playerSegments[i].ResetSegmentNumber(i);
        }
    }
}
