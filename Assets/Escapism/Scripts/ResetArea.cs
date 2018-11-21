using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetArea : MonoBehaviour {

    // Helper fucntion to reset objects
    private void OnTriggerEnter(Collider other)
    {
        // If object that enters trigger has a Resettable component, reset it
        Resettable r = other.GetComponent<Resettable>();
        if (r) r.StartReset();
    }
}