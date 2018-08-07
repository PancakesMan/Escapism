using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resettable : MonoBehaviour {

    Vector3 _Position;
    Quaternion _Rotation;

	// Use this for initialization
	void Start () {
        _Position = transform.position;
        _Rotation = transform.rotation;
	}

    public void Reset()
    {
        transform.position = _Position;
        transform.rotation = _Rotation;
    }
}
