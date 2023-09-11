using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    //public Transform startPoint, endPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    //    if (Vector2.Distance(PlayerData.instance.transform.position, transform.position) <= 5)
    //    {
    //        agent.enabled = true;
            //agent.SetDestination(target.position);
    //    }
    //    else
    //    {
    //        Patrol();
    //    }
    //}
    //private void Patrol()
    //{

    }
}
