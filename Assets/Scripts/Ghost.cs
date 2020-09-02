using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    private Player player;
    private NavMeshAgent _nma;
  
    public Transform _start;
   
    [SerializeField]
    private GameObject _scaredGhost;
    [SerializeField]
    private AudioSource _eatGhost;
    private UI_Manager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToMove());
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.canEatGhosts == false)
        {
            _nma.SetDestination(player.transform.position);
           
        } 
        else if (player.canEatGhosts == true)
        {
            StartCoroutine(RunAway());
        }

        if (transform.position.x >= 19f)
        {
            transform.position = new Vector3(-19f,transform.position.y, 0);
        } 
        else if ( transform.position.x <= -19f )
        {
            transform.position = new Vector3( 19f, transform.position.y, 0);
        } 
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player" && player.canEatGhosts == true)
        {
            this.transform.position = new Vector3 (1.3f, 2.78f, 1.64f);
            _eatGhost.Play();
            _scaredGhost.SetActive(false);
            player.canEatGhosts = false;
        }
        else if(other.tag == "Player" && player.canEatGhosts == false)
        {
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
        // transform.rotation = Quaternion.LookRotation(transform.position - _player.position);
        _nma.SetDestination((transform.position - player.transform.position));
        _scaredGhost.SetActive(true);
        yield return new WaitForSeconds(8f);
        StartCoroutine(FlashWarning());
        yield return new WaitForSeconds(10f);
        _scaredGhost.SetActive(false);
        player.canEatGhosts = false;
    }
    IEnumerator FlashWarning()
    {
        while(player.canEatGhosts == true)
        {
        _scaredGhost.SetActive(true);
        yield return new WaitForSeconds(1f);
        _scaredGhost.SetActive(false);
        yield return new WaitForSeconds(1f);
        }
    }

}
