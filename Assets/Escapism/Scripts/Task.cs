using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TaskState { Failed, Inactive, InProgress, Completed }

public class Task : MonoBehaviour {

    [System.Serializable]
    public class StartedEvent : UnityEvent { }
    [System.Serializable]
    public class CompletedEvent : UnityEvent { }
    [System.Serializable]
    public class FailedEvent : UnityEvent { }

    public string Description;

    public StartedEvent OnStarted;
    public CompletedEvent OnCompleted;
    public FailedEvent OnFailed;

    private TaskState _State;

	// Use this for initialization
	void Start () {
        _State = TaskState.Inactive;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTask()
    {
        // Set the TaskState to InProgress if it isn't already set and fire OnStarted event
        if (_State == TaskState.Inactive)
        {
            _State = TaskState.InProgress;
            OnStarted.Invoke();
        }
    }

    public void Complete()
    {
        // Set the TaskState to Complete from InProgress only and fire OnCompleted event
        if (_State == TaskState.InProgress)
        {
            _State = TaskState.Completed;
            OnCompleted.Invoke();
        }
    }

    public void Fail()
    {
        // Set the TaskState fo Failed from InProgress only and fire OnFailed event
        if (_State == TaskState.InProgress)
        {
            _State = TaskState.Failed;
            OnFailed.Invoke();
        }
    }
}
