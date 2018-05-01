using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killplayer : MonoBehaviour {
    public PlayerController gamePlayer;

    [SerializeField]
    Transform spawnPoint;

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        
            col.transform.position = gamePlayer.respawnPoint;
    }

}
