using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DetectMode { GameObject, Tag }

public class TriggeredByObject : MonoBehaviour {

    [System.Serializable]
    public class TriggerEnter : UnityEvent { }
    [System.Serializable]
    public class TriggerExit : UnityEvent { }

    public DetectMode detectMode;

    public GameObject ObjectTrigger;
    public string TagTrigger;

    public TriggerEnter OnTriggerEntered;
    public TriggerExit OnTriggerExited;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;

        switch (detectMode)
        {
            case DetectMode.GameObject:
                if (other.gameObject == ObjectTrigger)
                    OnTriggerEntered.Invoke();
                break;
            case DetectMode.Tag:
                if (other.gameObject.CompareTag(TagTrigger))
                    OnTriggerEntered.Invoke();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!enabled) return;

        switch (detectMode)
        {
            case DetectMode.GameObject:
                if (other.gameObject == ObjectTrigger)
                    OnTriggerExited.Invoke();
                break;
            case DetectMode.Tag:
                if (other.gameObject.CompareTag(TagTrigger))
                    OnTriggerExited.Invoke();
                break;
            default:
                break;
        }
    }
}
