// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class Cherry_Behavior : MonoBehaviour
// {
//     [SerializeField]
//     private Transform[] cherry_start;
//     private NavMeshAgent _nma;
//     [SerializeField]
//     private GameObject _cherryPrefab;
//     [SerializeField]
//     private Transform[] cherry_end;
//     public bool cherryActive = false;
//     public AudioSource _cherry;
//     private UI_Manager uiManager;

//     // Start is called before the first frame update
//     void Start()
//     {
//         _nma = this.GetComponent<NavMeshAgent>();
//         uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(cherryActive == false)
//         {
//             StartCoroutine(SpawnCherry());
//         }else
//         {  
//             MoveCherry();
//         }   
//     }
//     private void MoveCherry()
//     {
//         int randomExit = Random.Range(0,2);
//         _nma.SetDestination(cherry_end[randomExit].transform.position);
//     }
//     private void OnTriggerEnter(Collider other) 
//     {
//         if(other.tag == "Player")
//         {
//                 _cherry.Play();
//                 cherryActive = false;
//                 uiManager.currentScore += 100;
//                 uiManager.UpdateScore(uiManager.currentScore);
//                 Destroy(this.gameObject);
//         }
//     }
//     IEnumerator SpawnCherry()
//     {
//             yield return new WaitForSeconds(Random.Range(5,10));
//             int randomPos = Random.Range(0,4);
//             Vector3 posToSpawn = new Vector3(cherry_start[randomPos].transform.position.x, cherry_start[randomPos].transform.position.y, cherry_start[randomPos].transform.position.z);
//             Instantiate(_cherryPrefab, posToSpawn, Quaternion.identity);
//             cherryActive = true;
//             MoveCherry();
//     }
// }
