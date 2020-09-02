// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class Ghost : MonoBehaviour
// {
//     private Player player;
//     private NavMeshAgent _nma;
  
//     public Transform _start;
   
//     [SerializeField]
//     private GameObject _scaredGhost;
//     [SerializeField]
//     private AudioSource _eatGhost;
//     private UI_Manager uiManager;
//     private bool canBeEaten = false;

//     void Start()
//     {
//         StartCoroutine(WaitToMove());
//         player = GameObject.Find("Player").GetComponent<Player>();
//         uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();

//     }
    
//     void Update()
//     {
//         if(canBeEaten == false)
//         {
//             _nma.SetDestination(player.transform.position);
           
//         } 
//         else if (canBeEaten == true)
//         {
//             StartCoroutine(RunAway());
//         }

//         if (transform.position.x >= 19f)
//         {
//             transform.position = new Vector3(-19f,transform.position.y, 0);
//         } 
//         else if ( transform.position.x <= -19f )
//         {
//             transform.position = new Vector3( 19f, transform.position.y, 0);
//         } 
//     }
//     private void OnTriggerEnter(Collider other) 
//     {
//         if(other.tag == "Player" && canBeEaten == true)
//         {
//             this.transform.position = new Vector3 (1.3f, 2.78f, 1.64f);
//             _eatGhost.Play();
//             _scaredGhost.SetActive(false);    
//         }
//         else if(other.tag == "Player" && player.canEatGhosts == false)
//         {
            
//         }
//     }
//     IEnumerator WaitToMove()
//     {
//         yield return new WaitForSeconds(4.1f);
//         _nma = this.GetComponent<NavMeshAgent>();       
//     }
//     IEnumerator RunAway()
//     {
//         _nma.SetDestination((transform.position - player.transform.position));
//         _scaredGhost.SetActive(true);
//         yield return new WaitForSeconds(8f);
//         StartCoroutine(FlashWarning());
//     }
//     IEnumerator FlashWarning()
//     {
//         while(canBeEaten == true)
//         {
//         _scaredGhost.SetActive(true);
//         yield return new WaitForSeconds(1f);
//         _scaredGhost.SetActive(false);
//         yield return new WaitForSeconds(1f);
//         }
//     }

// }
