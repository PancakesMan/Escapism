using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resettable : MonoBehaviour {

    public Vector3 Position;
    public Vector3 Rotation;

    public Transform ResetTransform;

    public float ResetTime = 0.0f;

	// Use this for initialization
	void Start () {
        // If ResetTransform is not null
        if (ResetTransform)
        {
            // Set the reset Position and Rotation to be the ResetTransforms
            Position = ResetTransform.position;
            Rotation = ResetTransform.rotation.eulerAngles;
        }
	}

    public void StartReset()
    {
        // Reset object in ResetTime seconds
        Invoke("InstantReset", ResetTime);
    }

    public void InstantReset()
    {
        // Reset objects position and rotation
        transform.position = Position;
        transform.rotation = Quaternion.Euler(Rotation);
    }
}
