using UnityEngine;
using UnityEngine.AI;

public class zombieAI : MonoBehaviour
{
    public bool walk;
    NavMeshAgent _agent;
    public Animator _animator;
    public GameObject _Target;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _Target = GameObject.FindGameObjectWithTag("Player");

        // Spawn additional zombies
    }


    void Update()
    {
        if (_agent.enabled)
        {
            _agent.SetDestination(_Target.transform.position);
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _animator.SetBool("walk", false);
            }
            else
            {
                _animator.SetBool("walk", true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("attack", true); // Set attack animation when colliding with player
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("walk", true); // Set walk animation when no longer colliding with player
        }
    }
}
