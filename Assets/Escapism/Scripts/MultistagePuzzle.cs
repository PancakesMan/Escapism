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
        // Setup boolean array for puzzle stages
        _Stages = new bool[Stages];
    }
    // Use this for initialization
    void CheckPuzzleCompleted()
    {
        // Exit check if puzzle already completed
        if (_Completed) return;

        // Exit funciton if a stage is not completed
        foreach (bool b in _Stages)
            if (!b) return;

        // If all stages are complete, fire OnPuzzleCompleted event
        OnPuzzleCompleted.Invoke();
    }

    // Set the boolean at index in array to true
    public void MarkStageCompleted(int index)
    {
        // Exit if index doesn't exist
        if (index > _Stages.Length) return;

        // Set bool to true and fire event
        _Stages[index] = true;
        CheckPuzzleCompleted();
    }

    // Set the boolean at index in array to be false
    public void MarkStageIncomplete(int index)
    {
        // Exit if index doesn't exist
        if (index > _Stages.Length) return;

        // Set bool to false
        _Stages[index] = false;
    }
}
