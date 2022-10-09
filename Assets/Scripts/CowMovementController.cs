using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CowMovementController : MonoBehaviour
{
    [SerializeField] KeyCode[] _keys;
    [SerializeField] Transform[] _movePoints;
    [SerializeField] AnimationCurve _ease;
    [SerializeField] float _moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _keys.Length; i++)
        {
            if (Input.GetKeyDown(_keys[i]))
            {
                transform.DOMove(_movePoints[i].position, _moveSpeed).SetEase(_ease);
            }
        }

        
    }
}
