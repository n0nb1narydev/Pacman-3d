using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Clyde : MonoBehaviour
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
 
    void Start()
    {
        _nma = this.GetComponent<NavMeshAgent>();
         StartCoroutine(WaitToMove(4.1f));
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        // _nma = this.GetComponent<NavMeshAgent>();    
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
        if(player.isHit == true)
        {
            transform.position = _start.transform.position;
            StartCoroutine(WaitToMove(4.1f));    
        } 
    }
    void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "Player" && canBeEaten == true )
            {
                _scaredGhost.SetActive(false);
                canBeEaten = false;  
                uiManager.currentScore += 200;  
                uiManager.UpdateScore(uiManager.currentScore);
                StartCoroutine(player.EatsGhost()); 
                transform.position = _start.transform.position;
                StartCoroutine(WaitToMove(2f));
            }
            else if(other.tag == "Player" && canBeEaten == false)
            {
                StartCoroutine(player.HitPlayer());
            }
           
        } 

    IEnumerator WaitToMove(float time)
    {
        _nma.enabled = false;
        yield return new WaitForSeconds(time);
        _nma.enabled = true;        
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
