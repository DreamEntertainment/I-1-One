using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    private GameState gameState;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            TogglePauseMenu();      //have this check if the game is paused, and then have it unpause the game when pressed.
        }               
    }

    void TogglePauseMenu()
    {
        if (gameState == GameState.Playing)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        gameState = GameState.Paused;
    }

    void ResumeGame()
    {
        if (gameState == GameState.Paused)
        {
            Time.timeScale = 1f;
            gameState = GameState.Playing;
        }
    }
}
