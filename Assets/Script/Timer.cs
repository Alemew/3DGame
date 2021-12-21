using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public static Timer sharedInstance;
    
    public float limitTime = 10f;
    private float countdown = 0f;
    public bool startCountDowm = false;
    
    private void Awake()
    {
        sharedInstance = this;
    }
    
    public void StartTimer()
    {
        countdown = limitTime;
        startCountDowm = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDowm)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                startCountDowm = false;
                GameManager.sharedInstance.GameOver();
            } 
        }
    }
}
