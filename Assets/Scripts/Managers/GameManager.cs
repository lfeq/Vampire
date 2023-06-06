using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager s_instance;
    
    private GameState m_gameState;

    private void Awake() {
        if (s_instance != null && s_instance != this) {
            Destroy(gameObject);
        }
        s_instance = this;
        DontDestroyOnLoad(gameObject);
        m_gameState = GameState.None;
    }
    
    public void changeGameSate(GameState t_newState) {
        if(m_gameState == t_newState) {
            return;
        }
        m_gameState = t_newState;
        switch (m_gameState) {
            case GameState.None:
                break;
            case GameState.LoadMainMenu:
                break;
            case GameState.MainMenu:
                break;
            case GameState.Tutorial:
                break;
            case GameState.LoadLevel:
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new UnityException("Invalid Game State");
        }
    }
}

public enum GameState {
    None,
    LoadMainMenu,
    MainMenu,
    Tutorial,
    LoadLevel,
    Playing,
    GameOver
}
