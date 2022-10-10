using LlamAcademy.Spring;
using LlamAcademy.Spring.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class CowMovementController : MonoBehaviour
{
    [SerializeField] SpringToTarget2D _posSpring;
    [SerializeField] KeyCode[] _keys;
    [SerializeField] Transform[] _movePoints;
    [SerializeField] Transform _cowBody;

    [SerializeField] float _maxVel;
    [SerializeField] int _maxLaneMove;

    Vector2 _startScale;
    Vector2 _vel;



    Vector2 _lastPos;
    int _currentLane;


    void Start()
    {
        _lastPos = transform.position;
        _startScale = transform.localScale;
        MoveToLane(2);
        GameManager.OnGameStateChanged += OnGameManagerStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _keys.Length; i++)
        {
            if (Input.GetKeyDown(_keys[i]) && Mathf.Abs(_currentLane - i) <= _maxLaneMove)
            {
                MoveToLane(i);
            }
        }
    }

    void OnGameManagerStateChanged(GameManager.GameState nextState)
    {
        if (nextState == GameManager.GameState.TrickScreen)
        {
            //Debug.Log("Disabling movement");
            this.enabled = false;
        }


    }

    private void MoveToLane(int laneIndex)
    {
        _currentLane = laneIndex;
        _posSpring.SpringTo(_movePoints[_currentLane].position);
    }

    private void LateUpdate()
    {

        SquashAndStretch();
    }

    private void SquashAndStretch()
    {
        float stretch = _startScale.x + _startScale.x * Mathf.Abs(CalculateVelocity().x) / _maxVel;
        _cowBody.localScale = new Vector2(stretch, 1/stretch);
    }

    public Vector2 CalculateVelocity()
    {
        _vel = (_lastPos - (Vector2)transform.position) / Time.deltaTime;
        _lastPos = transform.position;
        return _vel;

    }
}
