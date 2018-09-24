using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DetectMode { GameObject, Tag }

public class TriggeredByObject : MonoBehaviour {

    [System.Serializable]
    public class TriggerEnter : UnityEvent<GameObject> { }
    [System.Serializable]
    public class TriggerExit : UnityEvent<GameObject> { }

    public DetectMode detectMode;

    public GameObject[] ObjectTrigger;
    public string[] TagTrigger;

    public TriggerEnter OnTriggerEntered;
    public TriggerExit OnTriggerExited;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;

        switch (detectMode)
        {
            case DetectMode.GameObject:
                foreach (GameObject go in ObjectTrigger)
                    if (other.gameObject == go)
                        OnTriggerEntered.Invoke(other.gameObject);
                break;
            case DetectMode.Tag:
                foreach(string tag in TagTrigger)
                    if (other.gameObject.CompareTag(tag))
                        OnTriggerEntered.Invoke(other.gameObject);
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
                foreach (GameObject go in ObjectTrigger)
                    if (other.gameObject == go)
                        OnTriggerExited.Invoke(other.gameObject);
                break;
            case DetectMode.Tag:
                foreach (string tag in TagTrigger)
                    if (other.gameObject.CompareTag(tag))
                        OnTriggerExited.Invoke(other.gameObject);
                break;
            default:
                break;
        }
    }
}
