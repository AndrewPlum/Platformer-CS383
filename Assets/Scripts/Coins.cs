using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
        public int maxHealth = 150;
    public int currentHealth;
    public CoinBar coinbar;
    public Entity entity; // Reference to the Entity script

    void Start()
    {
        currentHealth = maxHealth;
        coinbar.SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
