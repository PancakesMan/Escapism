using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetArea : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Resettable r = other.GetComponent<Resettable>();
        if (r) r.Reset();
    }
}
