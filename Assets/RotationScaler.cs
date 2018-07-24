﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis { X, Y, Z}

public class RotationScaler : MonoBehaviour {

    public GameObject rotator;
    public float ratio = 1.0f;
    public Axis axis = Axis.X;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float scale = 0.0f;

		switch (axis)
        {
            case Axis.X:
                transform.localScale = new Vector3(1 + (rotator.transform.localEulerAngles.x / ratio), transform.localScale.y, transform.localScale.z);
                break;
            case Axis.Y:
                transform.localScale = new Vector3(transform.localScale.x, 1 + (rotator.transform.localEulerAngles.y / ratio), transform.localScale.z);
                break;
            case Axis.Z:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1 + (rotator.transform.localEulerAngles.z / ratio));
                break;
            default:
                break;
        }
	}
}