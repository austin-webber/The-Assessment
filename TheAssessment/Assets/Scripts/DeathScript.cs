using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT RESPAWNS THE PLAYER AT A SPECIFIC POINT AFTER HITTING A COLLIDER TRIGGER

public class DeathScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            player.transform.rotation = respawnPoint.transform.rotation;
            Physics.SyncTransforms();
        }
    }
}
