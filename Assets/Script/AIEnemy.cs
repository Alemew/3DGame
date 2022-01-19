using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIEnemy : MonoBehaviour
{

    public enum EnemyState
    {
        PATROL,
        CHASE,
        ATTACK
    }

    [SerializeField] 
    private EnemyState _currentState = EnemyState.PATROL;

    public EnemyState CurrentState
    {
        get { return _currentState; }
        set
        {
            _currentState = value;
            StopAllCoroutines();
            switch (value)
            {
                case EnemyState.PATROL :
                {
                    _animator.SetBool("Attack", false);
                    StartCoroutine(AIPatrol());
                    break;
                }
                case EnemyState.CHASE :
                {
                    _animator.SetBool("Attack", false);
                    StartCoroutine(AIChase());
                    break;
                }
                case EnemyState.ATTACK :
                {
                    _animator.SetBool("Attack", true);
                    StartCoroutine(AIAttack());
                    break;
                }
            }
        }
    }

    private LineSight _theLineSight;
    private NavMeshAgent _theAgent;
    private Transform target;
    private Transform destination;
    public float pointsDamage = 10.0f;
    private Health targetHealth;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        targetHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            _theLineSight = GetComponent<LineSight>();
        _theAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameObject[] randomDestinations = GameObject.FindGameObjectsWithTag("Destination");
        destination = randomDestinations[Random.Range(0, randomDestinations.Length)].GetComponent<Transform>();
    }

    private void Start()
    {
        CurrentState = EnemyState.PATROL;
        
    }

    public IEnumerator AIPatrol()
    {
        while (CurrentState == EnemyState.PATROL)
        {
            _theLineSight.sensitivity = LineSight.SighSensitivity.STRICT;
            _theAgent.isStopped = false;
            _theAgent.SetDestination(destination.position);
            _theAgent.speed = 5;
            while (_theAgent.pathPending==true)
            {
                yield return null;
            }

            if (_theLineSight.canSeeTarget)
            {
                _theAgent.isStopped = true;
                CurrentState = EnemyState.CHASE;
                yield break;
            }

            yield return null;
        }
    }
    public IEnumerator AIChase()
    {
        while (CurrentState == EnemyState.CHASE)
        {
            _theLineSight.sensitivity = LineSight.SighSensitivity.LOOSE;
            _theAgent.isStopped = false;
            _theAgent.speed = 9;
            _theAgent.SetDestination(_theLineSight.lastKnowSight);
            while (_theAgent.pathPending==true)
            {
                yield return null;
            }

            if (_theAgent.remainingDistance<=_theAgent.stoppingDistance)
            {
                _theAgent.isStopped = true;
                if (_theLineSight.canSeeTarget == false)
                {
                    CurrentState = EnemyState.PATROL;
                }
                else
                {
                    CurrentState = EnemyState.ATTACK;
                }
                yield break;
            }

            yield return null;
        }
    }
    public IEnumerator AIAttack()
    {
        while (CurrentState == EnemyState.ATTACK)
        {
            _theAgent.isStopped = false;
            _theAgent.SetDestination(target.position);
            while (_theAgent.pathPending==true)
            {
                yield return null;
            }

            if (_theAgent.remainingDistance>_theAgent.stoppingDistance)
            {
                _theAgent.isStopped = true;
                CurrentState = EnemyState.CHASE;
                yield break;
            }
            else
            {
                targetHealth.HealthPoints -= pointsDamage * Time.deltaTime;
                Debug.Log(targetHealth.HealthPoints);
            }

            yield return null;
        }
    }
}
