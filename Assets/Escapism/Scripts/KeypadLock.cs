using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Lockable))]
public class KeypadLock : MonoBehaviour {

    public GameObject[] Code;

    private GameObject[] _CurrentCode;
    private int _Index = 0;

	// Use this for initialization
	void Start () {
        _CurrentCode = new GameObject[Code.Length];
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Button"))
        {
            if (other.name == "O")
            {
                for (int i = 0; i < _CurrentCode.Length; i++)
                    if (_CurrentCode[i] != Code[i]) return;

                // If the code is correct
                GetComponent<Lockable>().Locked = false;
            }
            else if (other.name == "X")
            {
                for (int i = 0; i < _CurrentCode.Length; i++)
                    _CurrentCode[i] = null;
            }
            else if (_Index < _CurrentCode.Length)
            {
                try
                {
                    int number = int.Parse(other.name);
                    if (number >= 0 && number < 10)
                    {
                        _CurrentCode[_Index++] = other.gameObject;
                    }
                }
                catch (Exception ex)
                {
                    // Shouldn't hit this exception
                    Debug.Log(ex.Message);
                }
            }
        }
    }
}