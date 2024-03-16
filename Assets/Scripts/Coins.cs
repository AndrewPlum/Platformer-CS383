using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public CoinBar coinbar;
    public Entity entity; // Reference to the Entity script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject); // Destroy the Coin object
            coinbar.UpdateHealth(10);
        }
    }

}
