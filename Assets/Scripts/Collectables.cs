using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private UI_Manager uiManager;
    private Player player;
    public AudioSource _cherry;
    private Ghost _blinky;
    private Ghost _pinky;
    private Ghost _inky;
    private Ghost _clyde;

    private void Start() 
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        // _blinky = GameObject.Find("Blinky").GetComponent<Ghost>();
        // _pinky = GameObject.Find("Pinky").GetComponent<Ghost>();
        // _inky = GameObject.Find("Inky").GetComponent<Ghost>();
        // _clyde = GameObject.Find("Clyde").GetComponent<Ghost>();
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
            uiManager.currentScore += 50;
            uiManager.UpdateScore(uiManager.currentScore);
            Destroy(this.gameObject);
            player.canEatGhosts = true;
        }   
    }



}
