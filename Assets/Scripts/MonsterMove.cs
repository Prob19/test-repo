using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] 
    private Transform player;
    [SerializeField]
    private float repathInterval = 0.1f;
    [SerializeField]
    private float stoppingDistance = 0.5f;

    private NavMeshAgent agent;
    private float nextRepathTime;






    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.updateRotation = true;
            agent.stoppingDistance = stoppingDistance;
            agent.autoBraking = false;
        }

        if(player == null)
        {
            GameObject found = GameObject.Find("Player");
            if (found != null) player = found.transform;
            //GameObject.FindGameObjectsWithTag("Player")?.transform;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextRepathTime)
        {
            nextRepathTime = Time.time + repathInterval;
            agent.SetDestination(player.position);
        }
    }
}
