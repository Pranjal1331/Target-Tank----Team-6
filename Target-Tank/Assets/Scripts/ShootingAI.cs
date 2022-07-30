using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingAI : MonoBehaviour
{
    #region Variables
    //Attack
    Transform player;
    public string sound;
    public Transform head, barrel, hull;
    public GameObject projectile;
    GameObject clone;
    public GameObject effect;
    public NavMeshAgent enemy;
    public float force;
    public float Firerate, nextfire;
    Vector3 distancebtw;
    
    //Patrolling
    public Vector3 walkpoint;
    public bool iswalkpoint;
    public float walkingRange;
    public LayerMask isGround;

    //Chasing
    public float sightRange, attackRange;
    public bool inSightRange, inAttackRange;
    #endregion
    #region Methods
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy =GetComponent<NavMeshAgent>();
    }

    
    void FixedUpdate()
    {
        if (player != null)
        {
            distancebtw = player.position - transform.position;
        }
        
        if(distancebtw.magnitude > sightRange && distancebtw.magnitude > attackRange)
        {
            Patrol();
        }
        else if (distancebtw.magnitude <= sightRange && distancebtw.magnitude > attackRange)
        {
            Chase();
        }
        else if (distancebtw.magnitude <= sightRange && distancebtw.magnitude <= attackRange)
        {
            Attack();
        }
        
    }

    
    void Patrol()
    {
        if (!iswalkpoint) SetWalkPoint();
        if (iswalkpoint)
        {
            enemy.SetDestination(walkpoint);
        }

        Vector3 distance = transform.position - walkpoint;
        if(distance.magnitude < 1f) iswalkpoint = false;
    }
    void SetWalkPoint()
    {
        float RandomX = Random.Range(-walkingRange, walkingRange);
        float RandomZ = Random.Range(-walkingRange, walkingRange);

        walkpoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);
        if(Physics.Raycast(walkpoint, -transform.up, 2f, isGround)) iswalkpoint = true;
    }

    void Attack()
    {
        enemy.SetDestination(transform.position);
        hull.LookAt(player);
        head.LookAt(player);
        
        if (Time.time >= nextfire)
        {
            nextfire = Time.time + 1f / Firerate;
            Shoot();
        }
    }

    void Chase()
    {
        enemy.SetDestination(player.transform.position);
    }

    void Shoot()
    {
        clone = Instantiate(projectile, barrel.position, head.rotation);
        GameObject eff = Instantiate(effect, barrel.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * force, ForceMode.Impulse);
        FindObjectOfType<AudioManager>().Play(sound);
        Destroy(eff, 1f);

    }
    #endregion
}
