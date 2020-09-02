using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pinky : MonoBehaviour
{
    private Player player;
    private NavMeshAgent _nma;
  
    public GameObject _start;
   
    [SerializeField]
    private GameObject _scaredGhost;
    [SerializeField]
    private AudioSource _eatGhost;
    private UI_Manager uiManager;
    public bool canBeEaten = false;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(WaitToMove());
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        _nma = this.GetComponent<NavMeshAgent>();    
    }

    
    void Update()
    {
        if(canBeEaten == false)
        {
            _nma.SetDestination(player.transform.position);
           
        } 
        else if (canBeEaten == true)
        {
            StartCoroutine(RunAway());
        }
        //allows ghosts to enter door and appear on other side
        if (transform.position.x >= 19f)
        {
            transform.position = new Vector3(-19f,transform.position.y, 0);
        } 
        else if ( transform.position.x <= -19f )
        {
            transform.position = new Vector3( 19f, transform.position.y, 0);
        }

        if(player.isDead == true)
        {
            transform.position = new Vector3(-0.115f, 2.28f, 0.7900001f);
        }   
    }
    void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "Player" && canBeEaten == true)
            {
                transform.position = _start.transform.position;
                _eatGhost.Play();
                _scaredGhost.SetActive(false);
                canBeEaten = false;    
            }
            else if(other.tag == "Player" && canBeEaten == false)
           {
                player.isDead = true;
                uiManager.UpdateLives(player.lives);
                player.DamagePlayer();
           }  
        } 

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(4.1f);
        _nma = this.GetComponent<NavMeshAgent>();       
    }
    IEnumerator RunAway()
    {
        _nma.SetDestination((transform.position - player.transform.position));
        _scaredGhost.SetActive(true);
        yield return new WaitForSeconds(8f);
        StartCoroutine(FlashWarning());
        yield return new WaitForSeconds(10f);
        _scaredGhost.SetActive(false);
        canBeEaten = false;
    }
    IEnumerator FlashWarning()
    {
        while(canBeEaten == true)
        {
        _scaredGhost.SetActive(true);
        yield return new WaitForSeconds(1f);
        _scaredGhost.SetActive(false);
        yield return new WaitForSeconds(1f);
        }
    }
}
