using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health;
    public int attackDamage;
    public float attackRange;

    public float attackSpeed;

    private float attackTimer;
    protected PlayerRPG player;
    protected NavMeshAgent navAgent;

    [SerializeField]
    protected float aggroRange = 30f;

    protected bool hasSeenPlayer = false;

    [SerializeField]
    protected List<Transform> patrolPoints = new List<Transform>();

    protected int patrolPointIndex = 0;

    public AudioSource AudioLibrary;

    
    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerRPG>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(patrolPoints[patrolPointIndex].position);
        navAgent.isStopped = false;
    }

    protected virtual void Update()
    {
        if (hasSeenPlayer == true)
        {
            if (navAgent.remainingDistance < 0.5f) 
            {
                if (Vector3.Distance(this.transform.position, player.transform.position) > aggroRange) 
                {
                    hasSeenPlayer = false; 

                }
                else 
                {
                    if (IsPlayerInLoS() == true) 
                    {
                        navAgent.SetDestination(player.transform.position); 
                        navAgent.isStopped = false; 
                    }
                    else 
                    {
                        hasSeenPlayer = false;
                    }
                }
            }


            
            if (Vector3.Distance(this.transform.position, player.transform.position) > attackRange)
            {
                if (IsPlayerInLoS() == true)
                {
                    navAgent.SetDestination(player.transform.position); 
                    navAgent.isStopped = false; 
                }
            }
            else 
            {
                if (IsPlayerInLoS() == true) 
                {
                    navAgent.isStopped = true; 
                    this.transform.LookAt(player.transform.position); 

                    attackTimer += Time.deltaTime; 

                    if (attackTimer > attackSpeed) 
                    {
                        Attack(); 
                        attackTimer = 0; 
                    }
                }
                else
                {
                    navAgent.isStopped = false;
                }
            }
        }
        else 
        {
            if (navAgent.remainingDistance < 0.5f) 
            {
                patrolPointIndex++; 

                if (patrolPointIndex >= patrolPoints.Count) 
                {
                    patrolPointIndex = 0; 
                }

                navAgent.SetDestination(patrolPoints[patrolPointIndex].position); 
                navAgent.isStopped = false; 
            }
        }

    }

    protected bool IsPlayerInLoS()
    {
        RaycastHit hit;

        Vector3 dir = player.transform.position - this.transform.position;
        dir.Normalize(); 

        if (Physics.Raycast(this.transform.position, dir, out hit))
        {

            if (hit.collider.tag == "Player")
            {
                return true;
            }

        }

        return false;
    }

    protected virtual void Attack()
    {
        player.TakeDamage(attackDamage);
        //Call an Animation to attack
        //OR
        //Deal Damage to the Player
    }
    protected virtual void RangedAttack()
    {
        player.TakeDamage(attackDamage);
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            
        }
    }
    

    public void Die()
    {
        //Call Death Animation
        //OR
        //Destroy the Object
    }

    public void SeePlayer()
    {
        if (IsPlayerInLoS() == true)
        {
            hasSeenPlayer = true;
        }
    }
}