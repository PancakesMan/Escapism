using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggeredByObject : MonoBehaviour {

    [System.Serializable]
    public class TriggerEnter : UnityEvent { }
    [System.Serializable]
    public class TriggerExit : UnityEvent { }

    public GameObject DetectTriggeredBy;

    public TriggerEnter OnTriggerEntered;
    public TriggerExit OnTriggerExited;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (enabled && other.gameObject == DetectTriggeredBy) OnTriggerEntered.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (enabled && other.gameObject == DetectTriggeredBy) OnTriggerExited.Invoke();
    }
}
