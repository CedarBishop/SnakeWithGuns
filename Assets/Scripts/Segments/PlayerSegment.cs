using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSegment : MonoBehaviour
{
    public float movementSpeed;
    public float segmentDistance = 0.5f;
    protected int segmentNumber;
    protected PlayerMovement player;

    protected bool initialised;

    public virtual void Init()
    {
        player = FindObjectOfType<PlayerMovement>();
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
        }
    }

    void MoveTowardsTargets(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) > segmentDistance)
        {
            Vector3 directionToTarget = (target - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.fixedDeltaTime);
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
}
