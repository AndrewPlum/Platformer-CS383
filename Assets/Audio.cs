using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] public AudioClip clickClip;
    [SerializeField] public AudioSource audioSource;

    public void Button(){
        audioSource.clip = clickClip;
        audioSource.Play();
    }
}
