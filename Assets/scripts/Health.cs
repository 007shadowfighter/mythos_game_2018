using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public PlayerController gamePlayer;

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public AudioSource deathSound;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
            deathSound.Play();
            transform.position = gamePlayer.respawnPoint;
            currentHealth = maxHealth;


        }
    }
}