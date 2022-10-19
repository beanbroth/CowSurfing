using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class CowCowTrickController : MonoBehaviour
{
    float _trickTime = 1f;

    [SerializeField] Collider2D _col;
    [SerializeField] float _startingUpVel;

    float _vel;
    bool _isTricking;

    void Start()
    {
        GameManager.OnGameStateChanged += OnGameManagerStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameManagerStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isTricking)
            return;

        if (_vel >= 0f)
        {
            transform.position += new Vector3(0f, _vel) * Time.deltaTime;
            _vel += Physics2D.gravity.y * Time.deltaTime;
        }
       
    }

    void OnGameManagerStateChanged(GameManager.GameState nextState)
    {
        if (nextState == GameManager.GameState.TrickScreen)
        {
            StartTricking();
        }

        if (nextState == GameManager.GameState.PlayingGame)
        {
            _isTricking = false;
            _vel = 0;
            _col.enabled = true;
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("crash!!");
        GameManager.Instance.SetNextGameState(GameManager.GameState.TrickScreen);
        
    }

    private void StartTricking()
    {
        _isTricking = true;
        _vel = _startingUpVel;
        _col.enabled = false;
    }
}
