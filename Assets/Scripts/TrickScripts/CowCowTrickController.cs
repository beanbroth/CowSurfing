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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isTricking)
            return;

        transform.position += new Vector3(0, _vel) * Time.deltaTime;
        _vel += Physics2D.gravity.y * Time.deltaTime;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("crash!!");
        GameManager.Instance.SetNextGameState(GameManager.GameState.TrickScreen);
        StartTricking();
    }

    private void StartTricking()
    {
        _isTricking = true;
        _vel = _startingUpVel;
        _col.enabled = false;
    }
}
