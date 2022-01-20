using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour
{
    
    public GameObject LifeAnimation;
    private Health playerHealth;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(LifeAnimation,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            playerHealth.moreLife();
            gameObject.SetActive(false);
            Invoke("destroyExplosion",2f);
        }
    }

    private void destroyExplosion()
    {
        Destroy(GameObject.Find("LifeAnimation(Clone)"));
        Destroy(gameObject);
    }

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
}
