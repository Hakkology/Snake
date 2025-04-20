using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    Playing,
    Options
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SetState(GameState.MainMenu);
    }

    public void SetState(GameState newState)
    {
        // Options yalnızca MainMenu'deyken açılabilir
        if (newState == GameState.Options && CurrentState != GameState.MainMenu)
        {
            Debug.LogWarning("Options yalnızca ana menüdeyken açılabilir.");
            return;
        }

        CurrentState = newState;

        switch (CurrentState)
        {
            case GameState.MainMenu:
                Debug.Log("Ana Menü Açıldı");
                SceneManager.LoadScene("MainMenu");
                break;

            case GameState.Playing:
                Debug.Log("Oyun Başlatılıyor...");
                SceneManager.LoadScene("Snake");
                break;

            case GameState.Options:
                Debug.Log("Ayarlar Menüsü Açıldı");
                // Sahne değişmiyor, aynı sahnedeki UI açılmalı
                break;

            default:
                Debug.LogWarning("Bilinmeyen GameState!");
                break;
        }
    }
}
