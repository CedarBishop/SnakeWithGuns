using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerMovement player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, 10, player.transform.position.z);
        }
    }
}
