using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private UI_Manager uiManager;
    public AudioSource _cherry;

    private void Start() 
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }
    private void OnTriggerEnter(Collider other) 
    {
    //     if(other.tag == "Player")
    //     {
    //         Destroy(this.gameObject);
    //     }
        if(this.tag == "Cherry")
        {
            _cherry.Play();
            uiManager.currentScore += 100;
            uiManager.UpdateScore(uiManager.currentScore);
            Destroy(this.gameObject);
        }
        else if (this.tag == "Yellow")
        {
            uiManager.currentScore += 10;
            uiManager.UpdateScore(uiManager.currentScore);
            Destroy(this.gameObject);
        }
        else if (this.tag == "White")
        {
            uiManager.currentScore += 10;
            uiManager.UpdateScore(uiManager.currentScore);
            Destroy(this.gameObject);
        }   
    }



}
