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
    private UI_Manager uiManager;
    public bool canBeEaten = false;
    [SerializeField]
    private AudioSource _eatGhost;
    // Start is called before the first frame update
    void Start()
    {
        _nma = this.GetComponent<NavMeshAgent>();  
         StartCoroutine(WaitToMove(4.1f));
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();  
    }

    
    void Update()
    {
        if(canBeEaten == false)
        {
            _nma.SetDestination(player.transform.position);
            _scaredGhost.SetActive(false); 
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
        if(other.tag == "Player" && canBeEaten == true && player.canEatGhosts == true) // 
        {
            _eatGhost.Play();  
            Respawn(2f);
            canBeEaten = false;  
  
        }
        else if(other.tag == "Player" && canBeEaten == false)
        {
            StartCoroutine(player.HitPlayer());
            Respawn(4.1f);
        }  
    } 

    IEnumerator WaitToMove(float count)
    {        
        _nma.enabled = false;
        yield return new WaitForSeconds(count);
        _nma.enabled = true;        
    }
    IEnumerator RunAway()
    {
        _nma.SetDestination((transform.position - player.transform.position));
        _scaredGhost.SetActive(true);
        yield return new WaitForSeconds(8f);
        StartCoroutine(FlashWarning());
        yield return new WaitForSeconds(10f);
        canBeEaten = false;
        _scaredGhost.SetActive(false);
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
    private void Respawn(float count)
    {
        transform.position = _start.transform.position;
        StartCoroutine(WaitToMove(count));
        player.ateGhost = false;
    }
}
