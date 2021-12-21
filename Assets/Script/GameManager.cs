using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using Update = UnityEngine.PlayerLoop.Update;

public enum GameState
{
    menu,
    inTheGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;

    public static GameManager sharedInstance;

    public Transform coins;

    public void CollectCoin()
    {
        if (coins.childCount==1)
        {
            GameOver();
        }
    }

    private void Awake()
    {
        sharedInstance = this;
    }

    public void StartGame()
    {
        
        ChangeStateGame(GameState.inTheGame);
    }

    public void GameOver()
    {
        ChangeStateGame(GameState.gameOver);
    }

    public void BackToMainMenu()
    {
        ChangeStateGame(GameState.menu);
    }

    void Start()
    {
        currentGameState = GameState.menu;
        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
    }

    void ChangeStateGame(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            currentGameState = GameState.menu;
            GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;

        }
        else if (newGameState == GameState.inTheGame)
        {
            GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
            Debug.Log("Comienzo");
            currentGameState = GameState.inTheGame;
            Timer.sharedInstance.StartTimer();
            
        }
        else
        {
            currentGameState = GameState.gameOver;
            GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
            if (Timer.sharedInstance.startCountDowm)
            {
                Timer.sharedInstance.startCountDowm = false;
                Debug.Log("Congratulations you won the game");
            }
            else
            {
                Debug.Log("You lose, try again");
            }
        }

    }
    void Update() {
        if (Input.GetButtonDown("Submit"))
        {
            if (currentGameState == GameState.menu)
            {
                StartGame();
            }

            if (currentGameState == GameState.gameOver)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}


