using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject explosion;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            GameManager.sharedInstance.CollectCoin();
            gameObject.SetActive(false);
            Invoke("destroyExplosion",1f);
        }
    }

    private void destroyExplosion()
    {
        Destroy(GameObject.Find("Explosion(Clone)"));
        Destroy(gameObject);
    }
    
    
}
