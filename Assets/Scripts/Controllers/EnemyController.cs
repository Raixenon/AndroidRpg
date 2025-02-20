﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    CharacterStats stats;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        stats = target.GetComponent<CharacterStats>();
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent <CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance+0.1)
            {
                if(stats != null)
                {
                    combat.Attack(stats);
                }
                FaceTarget();
            }
        }
    }


    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
