using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable : MonoBehaviour {

    public bool Locked = false;
    public VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider[] DisabledObjectsWhenUnlocked;

    private void Update()
    {
        if (Locked)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            foreach (VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider drawer in DisabledObjectsWhenUnlocked)
                drawer.enabled = true;
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            foreach (VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider drawer in DisabledObjectsWhenUnlocked)
                drawer.enabled = false;
        }
    }
}
