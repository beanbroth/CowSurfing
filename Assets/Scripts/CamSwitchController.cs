using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitchController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _stuntCam;
    void Start()
    {
        GameManager.OnGameStateChanged += OnGameManagerStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameManagerStateChanged;
    }
    void OnGameManagerStateChanged(GameManager.GameState nextState)
    {
        if (nextState == GameManager.GameState.TrickScreen)
        {
            _stuntCam.Priority = 20;
        }
    }
}
