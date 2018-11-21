using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelStatus : MonoBehaviour {

    [System.Serializable]
    public class LevelCompletedEvent : UnityEvent { }

    public string LevelName;
    public bool FireEventOnlyOnStart = false;
    private bool _Completed;

    public LevelCompletedEvent OnLevelCompleted;

	// Use this for initialization
	void Start () {
        // Check if the level was previously completed
        _Completed = PlayerPrefs.GetInt(LevelName + "Completed") == 1 ? true : false;

        // If it was fire the OnLevelCompleted event
        if (_Completed)
            OnLevelCompleted.Invoke();
	}

    // Mark the level as complete
    public void SetComplete()
    {
        // Exit if the level is already marked as complete
        if (_Completed) return;

        // Set the level as complete using PlayerPrefs
        PlayerPrefs.SetInt(LevelName + "Completed", 1);

        // Exit if the event should only fire when the level is loaded
        if (FireEventOnlyOnStart) return;

        // Fire event
        OnLevelCompleted.Invoke();
    }

    public bool GetCompleted()
    {
        return _Completed;
    }
}
