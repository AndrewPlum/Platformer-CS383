using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private CoinBar coinbar; // Reference to the CoinBar component
    
    void Start()
    {
        // Find and assign the CoinBar object based on its tag "CoinBar"
        GameObject coinbarObject = GameObject.FindWithTag("CoinBar");
        
        if (coinbarObject != null)
        {
            coinbar = coinbarObject.GetComponent<CoinBar>();
        }
        else
        {
            Debug.LogError("Coinbar not found. Make sure to tag your Coinbar GameObject with 'CoinBar'.");
        }

        // Assign the Coinbar instance to each Coin script attached to Coin GameObjects
        Coins[] coins = FindObjectsOfType<Coins>();
        foreach (Coins coin in coins)
        {
            coin.coinbar = coinbar;
        }
    }
}