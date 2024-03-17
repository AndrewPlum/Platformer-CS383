using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExcaliburStone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // player reached excalibur and won
        {
            //Debug.Log("You win!"); // Say you win
            SceneManager.LoadScene("VictoryScene"); 
        }
    }

}