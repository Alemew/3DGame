using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSight : MonoBehaviour
{

    public enum SighSensitivity
    {
        STRICT,
        LOOSE
    };

    public SighSensitivity sensitivity = SighSensitivity.STRICT;
    public bool canSeeTarget = false;
    public float fieldOfView = 45f;
    private Transform theTransform = null;
    private Transform target = null;
    public Transform eyePoint;
    private SphereCollider theCollider;
    public Vector3 lastKnowSight = Vector3.zero;

    private void Awake()
    {
        theTransform = GetComponent<Transform>();
        theCollider = GetComponent<SphereCollider>();
        lastKnowSight = theTransform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private bool InFieldOfView()
    {
        Vector3 directionToTheTarget = target.position - eyePoint.position;

        float angle = Vector3.Angle(eyePoint.forward, directionToTheTarget);
        if (angle <= fieldOfView)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
