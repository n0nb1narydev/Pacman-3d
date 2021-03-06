﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private UI_Manager uiManager;
    private Player player;
    private Blinky _blinky;
    private Pinky _pinky;
    private Inky _inky;
    private Clyde _clyde;
    public AudioSource _cherry;
    // private Cherry_Behavior _cherry;

    // public AudioSource _chase;
    // public AudioSource _background;
    
    

    private void Start() 
    {
        // _cherry = GameObject.Find("Cherry").GetComponent<Cherry_Behavior>();
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        _blinky = GameObject.Find("Blinky").GetComponent<Blinky>();
        _pinky = GameObject.Find("Pinky").GetComponent<Pinky>();
        _inky = GameObject.Find("Inky").GetComponent<Inky>();
        _clyde = GameObject.Find("Clyde").GetComponent<Clyde>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            if(this.tag == "Cherry")
            {
                _cherry.Play();
                // _cherryBehavior.cherryActive = false;
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
                StartCoroutine(PlayerCanEatGhosts());
                uiManager.currentScore += 50;
                uiManager.UpdateScore(uiManager.currentScore);
                Renderer rend = this.GetComponent<Renderer>();
                rend.enabled = false;
            }
        }   
    }

    IEnumerator PlayerCanEatGhosts()
    {
        player.canEatGhosts = true;
        _blinky.canBeEaten = true;
        _clyde.canBeEaten = true;
        _inky.canBeEaten = true;
        _pinky.canBeEaten = true;
        yield return new WaitForSeconds(10f);
        player.canEatGhosts = false;
        _blinky.canBeEaten = false;
        _clyde.canBeEaten = false;
        _inky.canBeEaten = false;
        _pinky.canBeEaten = false;
        Destroy(this.gameObject);
    }

}
