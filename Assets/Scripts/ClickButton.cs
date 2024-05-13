using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Sprite up, pressed;
    [SerializeField] private AudioClip compressClip, uncompressClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private Vector3 moveOffset;
    
    public void OnPointerDown(PointerEventData eventData) {
        img.sprite = pressed;
        audioSource.Play();
        if(playText != null){
            playText.rectTransform.localPosition += moveOffset;
        }
    }
    public void OnPointerUp(PointerEventData eventData){
        img.sprite=up;
        //audioSource.PlayOneShot(uncompressClip);
        if(playText != null){
            playText.rectTransform.localPosition -= moveOffset;
        }
    }

    public void SwitchScene(string sceneName){
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void LeaveTheGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
