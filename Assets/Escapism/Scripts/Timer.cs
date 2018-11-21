using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

    [System.Serializable]
    public class TimerCompletedEvent : UnityEvent { }

    public float TimerLength;
    public bool AutoStart = false;
    public float AutoStartDelay = 0.0f;

    public TimerCompletedEvent OnTimerCompleted;

    private float _timer;
    private bool started;

    private void Start()
    {
        if (AutoStart)
            Invoke("StartTimer", AutoStartDelay);
    }

    // Update is called once per frame
    void Update () {
        if (started)
        {
            // Update timer and check if it is finished
            _timer += Time.deltaTime;
            if (_timer > TimerLength)
            {
                // Reset timer and fire OnTimerCompleted event
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
