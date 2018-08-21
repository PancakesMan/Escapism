using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultistagePuzzle : MonoBehaviour {
    [System.Serializable]
    public class PuzzleCompleted : UnityEvent { }

    public int Stages;
    public PuzzleCompleted OnPuzzleCompleted;

    bool[] _Stages;
    bool _Completed = false;

    void Start()
    {
        _Stages = new bool[Stages];
    }
    // Use this for initialization
    void CheckPuzzleCompleted()
    {
        if (_Completed) return;

        foreach (bool b in _Stages)
            if (!b) return;

        OnPuzzleCompleted.Invoke();
    }

    public void MarkStageCompleted(int index)
    {
        if (index > _Stages.Length) return;

        _Stages[index] = true;
        CheckPuzzleCompleted();
    }

    public void MarkStageIncomplete(int index)
    {
        if (index > _Stages.Length) return;
        _Stages[index] = false;
    }
}
