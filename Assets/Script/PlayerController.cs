using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotateSpeed = 200.0f;
    private Animator _animator;
    public float x, y;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        transform.Rotate(0,x*rotateSpeed*Time.deltaTime,0);
        transform.Translate(0,0,y*moveSpeed*Time.deltaTime);
        
        _animator.SetFloat("SpeedX",x);
        _animator.SetFloat("SpeedY",y);
    }
}
