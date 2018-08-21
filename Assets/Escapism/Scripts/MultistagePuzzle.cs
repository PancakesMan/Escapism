using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultistagePuzzle : MonoBehaviour {
    [System.Serializable]
    public class PuzzleCompleted : UnityEvent { }

    public GameObject[] Objects;
    public PuzzleCompleted OnPuzzleCompleted;

	// Use this for initialization
	public void CheckObjectsEnabled()
    {
        foreach (GameObject go in Objects)
            if (!go.activeSelf)
                return;

        OnPuzzleCompleted.Invoke();
    }
}
