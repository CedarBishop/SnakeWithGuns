using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    public List<PlayerSegment> playerSegments = new List<PlayerSegment>();
    public int maxSegments;

    public float[] speedLevelStats;
    public float[] fireRateLevelStats;
    public AllyProjectile[] projectilesPerLevel;

    private int speedLevel;
    private int fireRateLevel;
    private int bulletsLevel;

    void RecalculateStats ()
    {
        foreach (PlayerSegment segment in playerSegments)
        {
            switch (segment.powerupType)
            {
                case PowerupType.None:
                    break;
                case PowerupType.Speed:
                    speedLevel += segment.powerupLevel;
                    break;
                case PowerupType.BulletsSpawned:
                    bulletsLevel += segment.powerupLevel;
                    break;
                case PowerupType.FireRate:
                    fireRateLevel += segment.powerupLevel;
                    break;
                default:
                    break;
            }
        }
    }

    public void ResetSegmentNumbers()
    {
        for (int i = 0; i < playerSegments.Count; i++)
        {
            playerSegments[i].ResetSegmentNumber(i);
        }

        RecalculateStats();
    }

    public float GetSpeedStat ()
    {
        if (speedLevel > speedLevelStats.Length - 1)
        {
            return speedLevelStats[speedLevelStats.Length - 1];
        }
        else
        {
            return speedLevelStats[speedLevel];
        }
        
    }

    public float GetFireRateStat()
    {
        if (fireRateLevel > fireRateLevelStats.Length - 1)
        {
            return fireRateLevelStats[fireRateLevelStats.Length - 1];
        }
        else
        {
            return fireRateLevelStats[fireRateLevel];
        }
    }

    public AllyProjectile GetProjectile()
    {
        if (bulletsLevel > projectilesPerLevel.Length - 1)
        {
            return projectilesPerLevel[projectilesPerLevel.Length - 1];
        }
        else
        {
            return projectilesPerLevel[bulletsLevel];
        }
    }
}
