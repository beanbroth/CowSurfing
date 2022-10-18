using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoteHitZoneController : MonoBehaviour
{
    [SerializeField] KeyCode[] _keys;
    [SerializeField] LayerMask _allNotesLayer;
    [SerializeField] LayerMask[] _layers;

    public static event Action<TrickNoteRollController.NoteKeys> OnNoteHit;
    public static event Action OnNoteMiss;

    [SerializeField] Color _pushColor;
    [SerializeField] Color _startingColor;
    SpriteRenderer _sr;

    Collider2D _col;


    void Start()
    {
        _col = GetComponent<Collider2D>();
        _sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        NoteHitCheck();


        _sr.color = Input.anyKey ? _pushColor : _startingColor;
    }

    private void NoteHitCheck()
    {
        for (int i = 0; i < _keys.Length; i++)
        {
            if (Input.GetKeyDown(_keys[i]))
            {
                {
                    Collider2D[] results = new Collider2D[1];
                    ContactFilter2D cf = new ContactFilter2D();
                    cf.layerMask = _allNotesLayer;

                    _col.OverlapCollider(cf, results);


                    if (results[0] != null)
                    {
                        OnNoteHit((TrickNoteRollController.NoteKeys)i);
                    }
                }
            }
        }
    }
}
