using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resettable : MonoBehaviour {

    public Vector3 Position;
    public Vector3 Rotation;

	// Use this for initialization
	void Start () {
        //_Position = transform.position;
        //_Rotation = transform.rotation;
	}

    public void Reset()
    {
        transform.position = Position;
        transform.rotation = Quaternion.Euler(Rotation);
    }
}
