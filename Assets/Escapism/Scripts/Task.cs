using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TaskState { Failed, NotStarted, InProgress, Completed }

public class Task : MonoBehaviour {

    public class StartedEvent : UnityEvent { }
    public class CompletedEvent : UnityEvent { }
    public class FailedEvent : UnityEvent { }

    public string Description;

    public StartedEvent OnStarted;
    public CompletedEvent OnCompleted;
    public FailedEvent OnFailed;

    private TaskState _State;

	// Use this for initialization
	void Start () {
        _State = TaskState.NotStarted;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTask()
    {
        if (_State == TaskState.NotStarted)
        {
            _State = TaskState.InProgress;
            OnStarted.Invoke();
        }
    }

    public void Complete()
    {
        if (_State == TaskState.InProgress)
        {
            _State = TaskState.Completed;
            OnCompleted.Invoke();
        }
    }

    public void Fail()
    {
        if (_State == TaskState.InProgress)
        {
            _State = TaskState.Failed;
            OnFailed.Invoke();
        }
    }
}
