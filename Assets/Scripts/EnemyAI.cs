using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public float updateRate = 0.1f;
    private float distToPlayer;
    private Transform target;
    private NavMeshAgent agent;
    private Coroutine FollowCoroutine;

    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    private Animator animator;

    public AudioClip hitClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // added by Jenny
        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


        StartChasing();
    }

    // Update is called once per frame
    void Update()
    {

        distToPlayer = Vector3.Distance(transform.position, target.position);
        if (distToPlayer < attackRange)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("attack", true);
            animator.SetFloat("Horizontal", (target.position.x - transform.position.x));
            animator.SetFloat("Vertical", target.position.y - transform.position.y);

            if (Time.time > lastAttackTime + attackDelay)
            {
                target.SendMessage("TakeDamage", damage);
                audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.PlayOneShot(hitClip);
                lastAttackTime = Time.time;
            }
        }

        // added by Jenny
        if (distToPlayer > attackRange)
        {
            animator.SetBool("attack", false);
            animator.SetBool("isMoving", true);
        }

    }

    public void StartChasing()
    {
        if (FollowCoroutine == null)
        {
            //Starting the FollotTarget coroutine that takes care of the enemies pathfinding towards the enemies
            StartCoroutine(FollowTarget());
        }
        else
        {
            Debug.LogWarning("Called StartChasing on Enemy that is already chasing");
        }
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(updateRate);

        while (enabled)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("Horizontal", (target.position.x - transform.position.x));
            animator.SetFloat("Vertical", target.position.y - transform.position.y);
            //Setting the target(player) for the enemies
            agent.SetDestination(target.transform.position);
            yield return Wait;
        }
    }



}
