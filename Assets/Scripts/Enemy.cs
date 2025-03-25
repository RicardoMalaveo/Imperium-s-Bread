using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyFrungle;
    public Transform ricktus;

    public NavMeshAgent agent;

    public LayerMask floor;
    public LayerMask player;


    //Patroling variables
    public List<Transform> wayPoints;
    public int targetWaytPoint;
    public float secondsBeforeMoving;
    bool walkPointReached = false;

    //States
    public float watchRange;
    public float attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        targetWaytPoint = 0;
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, watchRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        float distanceToWayPoint = Vector3.Distance(wayPoints[targetWaytPoint].position, transform.position);

        if (distanceToWayPoint <=0.25)
        {
            walkPointReached = true;
            targetWaytPoint = (targetWaytPoint + 1) % wayPoints.Count;
            StartCoroutine(WaitingBeforeMovingAgain());
        }

        if (!walkPointReached)
        {
            transform.LookAt(wayPoints[targetWaytPoint]);
            agent.SetDestination(wayPoints[targetWaytPoint].position);
            Debug.Log("Patroling");
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(ricktus.position);

        Debug.Log("Chasing player!");
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(ricktus);
        Debug.Log("Attacking player");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, watchRange);
    }

    private IEnumerator WaitingBeforeMovingAgain() 
    {
        yield return new WaitForSeconds(secondsBeforeMoving);
        walkPointReached = false;
    }

}
