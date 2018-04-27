using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public Vector3 respawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fallDetector") {
            transform.position = respawnPoint;
            if (other.tag == "Checkpoint")
            {
                respawnPoint = other.transform.position;
            }
        }
    }
}
        
    

