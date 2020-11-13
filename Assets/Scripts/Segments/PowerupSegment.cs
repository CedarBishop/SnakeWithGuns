using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum PowerupType { Speed, Damage}
public class PowerupSegment : PlayerSegment
{
    public PowerupType powerupType;
    public int powerupLevel = 1;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (CheckNeighbourSegment())
        {
            Merge();
        }
    }

    bool CheckNeighbourSegment ()
    {
        if (segmentNumber > 0)
        {
            if (segmentNumber < player.playerSegments.Count - 1)
            {
                if (powerupType == player.playerSegments[segmentNumber - 1].GetComponent<PowerupSegment>().powerupType &&
                    powerupLevel == player.playerSegments[segmentNumber - 1].GetComponent<PowerupSegment>().powerupLevel &&
                    powerupType == player.playerSegments[segmentNumber + 1].GetComponent<PowerupSegment>().powerupType &&
                    powerupLevel == player.playerSegments[segmentNumber + 1].GetComponent<PowerupSegment>().powerupLevel)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Merge ()
    {
        player.playerSegments[segmentNumber + 1].RemoveFromList();
        player.playerSegments[segmentNumber + 1].RemoveFromList();
        player.ResetSegmentNumbers();
        powerupLevel++;
    }
}


