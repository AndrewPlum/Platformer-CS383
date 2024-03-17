using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Entity entity; // Reference to the Entity script
    public TextMeshProUGUI healthText;
    public CoinBar coinBar;
    [SerializeField] public TextMeshProUGUI coinText;
    public int coinHealth;

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        coinBar = FindObjectOfType<CoinBar>(); // getting reference to coinbar for the game over screen
    }

    public void FixedUpdate()
    {
        // You can handle other player input or events here if needed

    }

    // Call this function to apply damage and handle collisions with obstacles
    public void HandleCollisions(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            TakeDamage(10);
            Destroy(collision.gameObject); // Destroy the obstacle
            /*if (currentHealth <= 0)
            {
               SceneManager.LoadScene("GameOver"); // Load the "GameOver" scene when health is 0 or below
            }*/
            // Add any other logic you need, like pausing or handling the jump over the obstacle
        }
        if (collision.transform.tag == "FinalBoss")
        {
            //Destroy(collision.gameObject); 
            //Access the EntityBoss script to change the state to deadState
            Entity boss = collision.gameObject.GetComponent<Entity>();
            if (boss != null)
            {
                boss.currentState = boss.deadState;
            }

            // Additional logic if needed, e.g., play death animation, disable controls, etc.
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.runtimeAnimatorController = boss.MushrioDead as RuntimeAnimatorController;
            }

            // Wait for 2.5 seconds before loading the "EndMenu" scene
            StartCoroutine(LoadGameOverSceneAfterDelay(2.5f));
        }
        //if (collision.transform.tag == "Sword")
        //{
        //    StartCoroutine(LoadVictorySceneAfterDelay(1f));
        //}
    }

    void TakeDamage(int damage)
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
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
    private IEnumerator LoadGameOverSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (coinBar != null){
            coinText = coinBar.coinText;
            coinHealth = coinBar.coinHealth;
            if(coinText != null){
                coinText.text = coinHealth.ToString() + " Points";
            }
        }
        // Load the game over scene
        SceneManager.LoadScene("GameOver"); 
    }
    /* extra if needed
    private IEnumerator LoadVictorySceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("VicrotyScene"); 
    } */
     public void ShowHealth()
    {
        healthText.text = "Health : " + currentHealth;
        // Start coroutine to reset the text after 2 seconds
        StartCoroutine(ResetTextAfterDelay(2f));
    }

    IEnumerator ResetTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Reset the text value
        healthText.text = "";
    }
}
