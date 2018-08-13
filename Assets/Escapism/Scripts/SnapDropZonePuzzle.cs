using System.Collections;
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
    public class PuzzleCompletedEvent : UnityEvent { }

    public PuzzleCompletedEvent OnPuzzleCompleted;

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
        foreach (DropAreaObjectConnector connector in List)
            if (connector.SnapDropZone.GetCurrentSnappedObject().name != connector.Object.name)
                return;

        OnPuzzleCompleted.Invoke();
    }
}
