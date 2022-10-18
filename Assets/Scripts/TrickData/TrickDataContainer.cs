using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrickDataContainer : ScriptableObject
{
    [SerializeField] public AnimationClip animationClip;
    [SerializeField] private TrickStep[] steps;

    public TrickStep[] Steps { get => steps; }
}

[System.Serializable]
public struct TrickStep
{
    public float startTimeUnit;
    public TrickNoteRollController.NoteKeys key;
    public int clipFrame;
}

