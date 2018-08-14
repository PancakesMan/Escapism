using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum LockType { Rigidbody, Interactable }

public class Lockable : MonoBehaviour {

    [System.Serializable]
    public class UnlockedEvent : UnityEvent { }

    [System.Serializable]
    public class LockedEvent : UnityEvent { }

    public LockType Type = LockType.Rigidbody;
    public bool Locked = false;
    public VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider[] DisabledObjectsWhenUnlocked;

    public LockedEvent OnLocked;
    public UnlockedEvent OnUnlocked;

    private void Update()
    {
        if (Locked)
        {
            switch (Type)
            {
                case LockType.Rigidbody:
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    break;
                case LockType.Interactable:
                    GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = false;
                    GetComponent<Rigidbody>().isKinematic = true;
                    break;
                default:
                    break;
            }
            foreach (VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider drawer in DisabledObjectsWhenUnlocked)
                drawer.enabled = true;
        }
        else
        {
            switch (Type)
            {
                case LockType.Rigidbody:
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    break;
                case LockType.Interactable:
                    GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = true;
                    GetComponent<Rigidbody>().isKinematic = false;
                    break;
                default:
                    break;
            }
            foreach (VRTK.Controllables.PhysicsBased.VRTK_PhysicsSlider drawer in DisabledObjectsWhenUnlocked)
                drawer.enabled = false;
        }
    }

    public void Lock()
    {
        Locked = true;
        OnLocked.Invoke();
    }

    public void Unlock()
    {
        Locked = false;
        OnUnlocked.Invoke();
    }
}
