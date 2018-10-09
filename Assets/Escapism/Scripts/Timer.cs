using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

    [System.Serializable]
    public class TimerCompletedEvent : UnityEvent { }

    public float TimerLength;
    public TimerCompletedEvent OnTimerCompleted;

    private float _timer;
    private bool started;

	// Update is called once per frame
	void Update () {
        if (started)
        {
            _timer += Time.deltaTime;
            if (_timer > TimerLength)
            {
                ResetTimer();
                OnTimerCompleted.Invoke();
            }
        }
	}

    public void StartTimer()
    {
        started = true;
    }

    public void PauseTimer()
    {
        started = false;
    }

    public void ResetTimer()
    {
        started = false;
        _timer = 0.0f;
    }

    public float GetTime()
    {
        return _timer;
    }
}
