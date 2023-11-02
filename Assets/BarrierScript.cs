using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public float barrierDistance = 5.0f; // Adjust this distance as needed

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the barrier is the player (or the camera)
        if (other.CompareTag("Player"))  // You need to set the player's tag
        {
            // Determine the distance between the player and the barrier
            float distanceToBarrier = Vector3.Distance(transform.position, other.transform.position);

            // If the player gets too close to the barrier, move them away
            if (distanceToBarrier < barrierDistance)
            {
                // Move the player back or apply some action (e.g., fade to black, show a warning message, etc.)
                // You can use other methods like teleportation or pushing the player's GameObject.

                // For example, you can use teleportation to move the player:
                Vector3 newPosition = other.transform.position - (other.transform.position - transform.position).normalized * barrierDistance;
                other.transform.position = newPosition;
            }
        }
    }
}
