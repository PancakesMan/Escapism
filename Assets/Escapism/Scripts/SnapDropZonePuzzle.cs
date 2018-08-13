﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

[System.Serializable]
public struct DropAreaObjectConnector
{
    public VRTK_SnapDropZone  SnapDropZone;
    public GameObject         Object;
}

public class SnapDropZonePuzzle : MonoBehaviour {

    public DropAreaObjectConnector[] List;

    [System.Serializable]
    public class PuzzleCompletedCorrectlyEvent : UnityEvent { }

    [System.Serializable]
    public class PuzzleCompletedIncorrectlyEvent : UnityEvent { }

    public PuzzleCompletedCorrectlyEvent OnPuzzleCompletedCorrectly;
    public PuzzleCompletedIncorrectlyEvent OnPuzzleCompletedIncorrectly;

	// Use this for initialization
	void Start () {
		foreach (DropAreaObjectConnector connector in List)
        {
            connector.SnapDropZone.ObjectSnappedToDropZone += ObjectSnappedHandler;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ObjectSnappedHandler(object sender, SnapDropZoneEventArgs e) {
        int correctCount = 0;

        foreach (DropAreaObjectConnector connector in List)
        {
            // If a snap zone has no object, puzzle can't be complete
            if (!connector.SnapDropZone.GetCurrentSnappedObject()) return;

            if (connector.SnapDropZone.GetCurrentSnappedObject().name == connector.Object.name)
                correctCount++;
        }

        if (correctCount == List.Length)
        {
            OnPuzzleCompletedCorrectly.Invoke();
            foreach (DropAreaObjectConnector connector in List)
            {
                connector.SnapDropZone.GetCurrentSnappedObject().GetComponent<VRTK_InteractableObject>().isGrabbable = false;
            }
            enabled = false;
        }
        else
            OnPuzzleCompletedIncorrectly.Invoke();
    }
}
