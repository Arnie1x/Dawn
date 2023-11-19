using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DestructibleBase
{
    private UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public float attackSpeed = 5f;
    public int attackDamage = 0;
    public bool alreadyAttacked;
    public GameObject shootPoint;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        // player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.destination = walkPoint;

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        // agent.SetDestination(player.position);
        agent.destination = player.position;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        // agent.SetDestination(transform.position);
        // agent.destination = player.position;

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            GameObject _projectile = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
            Rigidbody rb = _projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * attackSpeed, ForceMode.Impulse);
            // rb.AddForce(transform.up, ForceMode.Impulse);

            projectile.GetComponent<Projectile>().damage = attackDamage;
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}


