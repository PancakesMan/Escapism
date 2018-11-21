using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis { X, Y, Z}

public class RotationScaler : MonoBehaviour {

    public GameObject rotator;
    public float ratio = 1.0f;
    public Axis RotationAxis = Axis.X;
    public Axis ScaleAxis = Axis.X;

    public float rotatorAngle;
    float lastAngle;

	// Use this for initialization
	void Start () {
        rotatorAngle = rotator.transform.localEulerAngles[(int)RotationAxis];
        lastAngle = rotatorAngle;
    }
	
	// Update is called once per frame
	void Update () {
        // determine change in rotation of rotator object
        float deltaAngle = Mathf.DeltaAngle(rotator.transform.localEulerAngles[(int)RotationAxis], lastAngle);
        lastAngle = rotator.transform.localEulerAngles[(int)RotationAxis];
        rotatorAngle += deltaAngle;

        // Update the scale of this object based on rotation of rotator
        float scale =  rotatorAngle/ ratio;
        Vector3 newScale = transform.localScale;
        newScale[(int)ScaleAxis] = 1 + scale;
        transform.localScale = newScale;

        /*
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
        }*/
	}
}
