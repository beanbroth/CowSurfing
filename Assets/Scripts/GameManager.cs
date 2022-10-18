using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameState _startingGameState;

    private static GameManager _instance;
    private GameState _state;
    private bool _shouldUpdateState;

    private GameState _nextSate;

    public static event Action<GameState> OnGameStateChanged;

    public static GameManager Instance { get { return _instance; } }

    public GameState CurrentState { get => _state; }


    public enum GameState
    {
        MainMenu,
        PlayingGame,
        TrickScreen,
        Dead,
        PauseMenu,
        LossScreen
    }

    private void Start()
    {
        MakeSingleton();
        SetNextGameState(GameState.PlayingGame);
        SetNextGameState(_startingGameState);
    }


    private void FixedUpdate()
    {
        if (!_shouldUpdateState)
            return;

        _shouldUpdateState = false;
        _state = _nextSate;
        UpdateGameState(_nextSate);
    }

    public void SetNextGameState(GameState newState)
    {
        _nextSate = newState;
        _shouldUpdateState = true;
    }

    private void UpdateGameState(GameState newState)
    {
        _state = newState;

        switch (_state)
        {
            case GameState.MainMenu:
                break;
            case GameState.PlayingGame:
                break;
            case GameState.TrickScreen:
                break;
            case GameState.Dead:
                break;
            case GameState.PauseMenu:
                break;
            case GameState.LossScreen:
                break;
            default:
                Debug.Log("Shouldn't be here, something bad happened");
                break;
        }

        Debug.Log(_state);
        OnGameStateChanged?.Invoke(_state);
    }

    private void MakeSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //DontDestroyOnLoad(gameObject);
            _instance = this;
        }
    }
}
