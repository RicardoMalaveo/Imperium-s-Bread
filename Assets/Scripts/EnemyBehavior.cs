using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
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
    public bool playerRange;
    public bool playerInAttackRange;

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
        //Checking if player is in range and if the enemy can attack.
        playerRange = Physics.CheckSphere(transform.position, watchRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);

        //allows the enemy to switch between chasing the player, attacking and patroling
        if (!playerRange && !playerInAttackRange) Patroling();
        if (playerRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerRange) AttackPlayer();
    }

    private void Patroling()
    {
        //calculates the current distance between the enemy and the next waypoint.
        float distanceToWayPoint = Vector3.Distance(wayPoints[targetWaytPoint].position, transform.position);

        //allows to check if the waypoint has been reached.
        if (distanceToWayPoint <= 0.25)
        {
            walkPointReached = true;
            targetWaytPoint = (targetWaytPoint + 1) % wayPoints.Count;
            StartCoroutine(WaitingBeforeMovingAgain());
        }

        //the enemy will walk toward the waypoint while looking at it
        if (!walkPointReached)
        {
            transform.LookAt(wayPoints[targetWaytPoint]);
            agent.SetDestination(wayPoints[targetWaytPoint].position);
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(ricktus.position);
    }

    private void AttackPlayer()
    {
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

    //wait a few seconds once it reaches the waypoint to then move to the next waypoint.
    private IEnumerator WaitingBeforeMovingAgain()
    {
        yield return new WaitForSeconds(secondsBeforeMoving);
        walkPointReached = false;
    }

}

