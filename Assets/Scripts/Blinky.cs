using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blinky : MonoBehaviour
{
    private Player player;
    private NavMeshAgent _nma;
  
    public Transform _start;
   
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

    // Update is called once per frame
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
        }   
    } 
    IEnumerator WaitToMove()
    {
        _nma.enabled = false;
        yield return new WaitForSeconds(4.1f);
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
