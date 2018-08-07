using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable : MonoBehaviour {

    public bool Locked = false;

    private void Update()
    {
        if (Locked)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else { GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; }
    }
}
