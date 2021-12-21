using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private bool ClearLineOfSight()
    {
        Vector3 directionToTheTargetNormalized = (target.position - eyePoint.position).normalized;

        RaycastHit raycastInfo;

        if (Physics.Raycast(eyePoint.position, directionToTheTargetNormalized,out raycastInfo, theCollider.radius))
        {
            if (raycastInfo.transform.CompareTag("Player"))
            {
                return true;
            } 
        }
        return false;
    }

    private void UpdateSight()
    {
        switch (sensitivity)
        {
            case SighSensitivity.STRICT:
            {
                canSeeTarget = InFieldOfView() && ClearLineOfSight();
                break;
            }
            case SighSensitivity.LOOSE:
            {
                canSeeTarget = InFieldOfView() || ClearLineOfSight();
                break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateSight();

            if (canSeeTarget)
            {
                lastKnowSight = target.position;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSeeTarget = false;
        }
    }
}
