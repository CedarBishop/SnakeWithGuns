using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType { None, Speed, BulletsSpawned, FireRate }

public class PlayerSegment : MonoBehaviour
{
    public float movementSpeed;
    public float segmentDistance = 0.5f;
    public PowerupType powerupType;
    public int powerupLevel = 1;

    protected int segmentNumber;
    protected PlayerPowerups player;

    protected bool initialised;
    [HideInInspector] public bool hasReachedTargetOnce = false;

    public virtual void Init()
    {
        player = FindObjectOfType<PlayerPowerups>();
        if (player.playerSegments.Count >= player.maxSegments)
        {
            Destroy(gameObject);
        }
        player.playerSegments.Add(this);
        segmentNumber = player.playerSegments.Count - 1;
        initialised = true;
    }

    protected virtual void FixedUpdate()
    {
        if (initialised)
        {
            if (segmentNumber == 0)
            {
                MoveTowardsTargets(player.transform.position);
            }
            else
            {
                MoveTowardsTargets(player.playerSegments[segmentNumber - 1].transform.position);
            }

            CheckNeighbourSegment();
        }
    }

    void MoveTowardsTargets(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) > segmentDistance)
        {
            Vector3 directionToTarget = (target - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.fixedDeltaTime);
        }
        else
        {
            hasReachedTargetOnce = true;
        }
    }

    public void ResetSegmentNumber (int index)
    {
        segmentNumber = index;
    }

    public void RemoveFromList()
    {
        player.playerSegments.Remove(this);
        Destroy(gameObject);
    }

    void CheckNeighbourSegment()
    {
        if (segmentNumber == 0)
        {
            return;
        }
        if (powerupType == PowerupType.None)
        {
            return;
        }
        if (hasReachedTargetOnce == false)
        {
            return;
        }

        if (segmentNumber < player.playerSegments.Count - 1)
        {
            if (powerupType == player.playerSegments[segmentNumber - 1].powerupType &&
                powerupLevel == player.playerSegments[segmentNumber - 1].powerupLevel &&
                player.playerSegments[segmentNumber - 1].hasReachedTargetOnce &&
                powerupType == player.playerSegments[segmentNumber + 1].powerupType &&
                powerupLevel == player.playerSegments[segmentNumber + 1].powerupLevel &&
                player.playerSegments[segmentNumber + 1].hasReachedTargetOnce)
            {
                Merge();
            }
        }
    }

    void Merge()
    {
        player.playerSegments[segmentNumber + 1].RemoveFromList();
        player.playerSegments[segmentNumber - 1].RemoveFromList();
        player.ResetSegmentNumbers();
        powerupLevel++;
        print("Merge");
    }
}
