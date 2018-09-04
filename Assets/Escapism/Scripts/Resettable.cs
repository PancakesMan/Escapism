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
        if (ResetTransform)
        {
            Position = ResetTransform.position;
            Rotation = ResetTransform.rotation.eulerAngles;
        }
	}

    public void StartReset()
    {
        Invoke("InstantReset", ResetTime);
    }

    public void InstantReset()
    {
        transform.position = Position;
        transform.rotation = Quaternion.Euler(Rotation);
    }
}
