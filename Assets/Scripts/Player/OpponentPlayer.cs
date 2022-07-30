using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentPlayer : MonoBehaviour
{

    NavMeshAgent navmeshagent;
    public Transform Finish;

  
    private Transform OpponentPosition;
    private Vector3 startPosition;

    float swerve;
    void Start() {
        OpponentPosition=GetComponent<Transform>();
        startPosition=GetComponent<Transform>().position;
        navmeshagent=GetComponent<NavMeshAgent>();

        

    }

    void Update (){
        navmeshagent.SetDestination(Finish.position);
    
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle" )
        {
            OpponentPosition.transform.position= startPosition;
        }
     
        
        }
    
}