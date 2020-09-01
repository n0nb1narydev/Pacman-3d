using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public AudioSource _cherry;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if(this.tag == "Cherry")
        {
            _cherry.Play();
        }    
    }



}
