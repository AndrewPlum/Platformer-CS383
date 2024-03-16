using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject player; // Reference to the Player GameObject

    void Start()
    {
        // Find and assign the Player object based on its tag "Player"
        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure to tag your Player GameObject with 'Player'.");
        }

        // Assign the Player instance to each Enemy script attached to Enemy GameObjects
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.player = player;
        }
    }
}