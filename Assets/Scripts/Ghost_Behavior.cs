using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost_Behavior : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent _nma;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToMove());
    }

    // Update is called once per frame
    void Update()
    {
        _nma.SetDestination(player.transform.position);    
    }
    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(4.1f);
        _nma = this.GetComponent<NavMeshAgent>(); 
    
          
    }
}
