using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public static Health sharedInstance;
    
    [SerializeField]
    private float _healthPoints = 100.0f;

    public float HealthPoints
    {
        get { return _healthPoints; }
        set
        {
            _healthPoints = value;
            if (_healthPoints <=0)
            {
                Debug.Log("Has muerto");
                Destroy(gameObject);
            }
        }
    }

    public void moreLife()
    {
        if (_healthPoints != 100.0f)
        {
            _healthPoints = 100.0f;
        }
    }
    
}
