using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    //public int maxCoins = 150;
    //public int currentHealth;
    public CoinBar coinbar;
    public Entity entity; // Reference to the Entity script

    void Start()
    {
        //currentHealth = maxHealth;
        //coinbar.SetMaxHealth();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */

    /*
    // Call this function to apply damage and handle collisions with obstacles
    public void CollisionHandler(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //AddCoins(10);
            Destroy(collision.gameObject); // Destroy the obstacle
            // Add any other logic you need, like pausing or handling the jump over the obstacle
        }
    }
    //*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject); // Destroy the Coin object
            coinbar.UpdateHealth(100);
        }
    }
/*
    void AddCoins(int coinScore)
    {
        if (currentHealth < 20)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);

            // Access the Entity script to change the state to deadState
            Entity entity = GetComponent<Entity>();
            if (entity != null)
            {
                entity.currentState = entity.deadState;
            }

            // Additional logic if needed, e.g., play death animation, disable controls, etc.
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.runtimeAnimatorController = entity.MushrioDead as RuntimeAnimatorController;
            }

            // Wait for 5 seconds before loading the game over scene
            StartCoroutine(LoadGameOverSceneAfterDelay(2.5f));
        }
        else
        {
            currentHealth -= coinScore;
            healthBar.SetHealth(currentHealth);
        }
    }
    */
}
