using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickMinigameController : MonoBehaviour
{
    [SerializeField] Transform _cow;
    [SerializeField] GameObject _cowOffset;
    void Start()
    {
        GameManager.OnGameStateChanged += OnGameManagerStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameManagerStateChanged;
    }

    void Update()
    {
        transform.position = _cow.transform.position;
    }

    void OnGameManagerStateChanged(GameManager.GameState nextState)
    {
        if (nextState == GameManager.GameState.TrickScreen)
        {
            _cowOffset.SetActive(true);
        }

        if (nextState == GameManager.GameState.PlayingGame)
        {
            _cowOffset.SetActive(false);
        }
    }

}
