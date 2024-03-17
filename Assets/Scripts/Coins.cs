using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public CoinBar coinbar;
    //public Entity entity; // Reference to the Entity script
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject); // Destroy the Coin object
            coinbar.UpdateHealth(10);
        } 
    }

}
