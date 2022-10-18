using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TrickNoteRollController : MonoBehaviour
{
    public enum NoteKeys
    {
        LeftArrow,
        DownArrow,
        UpArrow,
        RightArrow
    };

    [SerializeField] GameObject _cowBody;
    [SerializeField] GameObject[] _notePrefabs;
    [SerializeField] float _noteGap;
    [SerializeField] int _startGap;


    [SerializeField] Transform _spawnOrigin;

    [SerializeField] TrickDataContainer[] allTricks;
    [SerializeField] float _bpm;

    [SerializeField] KeyCode[] _keys;
    [SerializeField] Transform[] noteLanes;

    TrickDataContainer _currentTrickDataContainer;
    int _currentTrickStep;

    List<GameObject> allNotes = new List<GameObject>();



    private void Start()
    {

        NoteHitZoneController.OnNoteHit += NoteHit;

        StartTrick();
    }

    private void StartTrick()
    {
        //pick which trick you want to do
        _currentTrickDataContainer = allTricks[0];

        //generate notes based on that trick
        GenerateNoteRoll(_currentTrickDataContainer);

        _currentTrickStep = 0;
    }

    private void GenerateNoteRoll(TrickDataContainer trickDataContainer)
    {
        for (int i = 0; i < trickDataContainer.Steps.Length; i++)
        {
            float startTime = trickDataContainer.Steps[i].startTimeUnit;


            GameObject notePefab = _notePrefabs[(int)trickDataContainer.Steps[i].key];
            Vector3 spawnPos = _spawnOrigin.position + (((Vector3.right * _startGap) + Vector3.right * startTime) * _noteGap);

            GameObject tempNote = Instantiate(notePefab, spawnPos, Quaternion.identity, transform);
            allNotes.Add(tempNote);
        }
    }

    private void NoteHit(NoteKeys noteKey)
    {
        Debug.Log("the note that was pressed was " + noteKey);
        if (noteKey == _currentTrickDataContainer.Steps[_currentTrickStep].key)
        {
            Debug.Log("Hit the correct key");
            Destroy(allNotes[_currentTrickStep]);
            _currentTrickDataContainer.animationClip.SampleAnimation(_cowBody, _currentTrickDataContainer.Steps[_currentTrickStep].clipFrame / _currentTrickDataContainer.animationClip.frameRate);

            _currentTrickStep++;


        }
        else
        {
            Debug.Log("Hit the incorrect key FAILURE FAUILURE EEB EBBE EBB");
        }

    }

    void Update()
    {
        transform.position += Vector3.left * _noteGap * _bpm / 60 * Time.deltaTime;
    }
}
