using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ClawPickup : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Claw hit " + other.gameObject.name);
        GetComponentInChildren<VRTK_SnapDropZone>().ForceSnap(other.gameObject);
        Debug.Log("Claw snapped object is: " + GetComponentInChildren<VRTK_SnapDropZone>().GetCurrentSnappedObject().name);
    }
}
