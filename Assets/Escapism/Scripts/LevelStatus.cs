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
        _Completed = PlayerPrefs.GetInt(LevelName + "Completed") == 1 ? true : false;
        if (_Completed)
            OnLevelCompleted.Invoke();
	}

    public void SetComplete()
    {
        if (_Completed) return;
        PlayerPrefs.SetInt(LevelName + "Completed", 1);

        if (FireEventOnlyOnStart) return;
        OnLevelCompleted.Invoke();
    }

    public bool GetCompleted()
    {
        return _Completed;
    }
}
