using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FollowDestination : MonoBehaviour
{
    private NavMeshAgent theAgent = null;

    public Transform destination;

    private void Awake()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        GameObject[] randomDestinations = GameObject.FindGameObjectsWithTag("Destination");
        destination = randomDestinations[Random.Range(0, randomDestinations.Length)].GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        theAgent.SetDestination(destination.position);
    }
}
