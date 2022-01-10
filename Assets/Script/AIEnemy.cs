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
                    StartCoroutine(AIPatrol());
                    break;
                }
                case EnemyState.CHASE :
                {
                    StartCoroutine(AIChase());
                    break;
                }
                case EnemyState.ATTACK :
                {
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

    private void Awake()
    {
        _theLineSight = GetComponent<LineSight>();
        _theAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        CurrentState = EnemyState.PATROL;
        GameObject[] randomDestinations = GameObject.FindGameObjectsWithTag("Destination");
        destination = randomDestinations[Random.Range(0, randomDestinations.Length)].GetComponent<Transform>();
    }

    public IEnumerator AIPatrol()
    {
        yield break;
    }
    public IEnumerator AIChase()
    {
        yield break;
    }
    public IEnumerator AIAttack()
    {
        yield break;
    }
}
