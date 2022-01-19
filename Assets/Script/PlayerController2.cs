using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [Range(1,10)]
    public float moveSpeed = 5.0f;
    [Range(1,10)]
    public float jumpForce = 10.0f;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x * moveSpeed , _rigidbody.velocity.y, y * moveSpeed);
        
        _animator.SetFloat("SpeedX",x);
        _animator.SetFloat("SpeedY",y);

        _rigidbody.velocity = movement;
        

    }
}
