using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JointBreakEvent : MonoBehaviour {

    [System.Serializable]
    public class JointBreakingEvent : UnityEvent { }

    public JointBreakingEvent OnJointBreaking;

    // Helper function to allow editor event when joint is broken
    private void OnJointBreak(float breakForce)
    {
        OnJointBreaking.Invoke();
    }
}
