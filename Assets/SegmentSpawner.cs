using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    public PlayerSegment segmentPrefab;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            Instantiate(segmentPrefab, transform.position, Quaternion.identity);
        }
    }

   
}
