using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadLock : MonoBehaviour {

    public Lockable Lock;
    public GameObject[] Code;
    public Text CodeDisplay;

    public GameObject[] _CurrentCode;
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
                // If no numbers have been entered
                // Don't try comparing the code
                if (_Index == 0) return;

                for (int i = 0; i < _CurrentCode.Length; i++)
                    if (_CurrentCode[i].name != Code[i].name) return;

                // If the code is correct
                Lock.Unlock();
                other.transform.parent.parent = other.transform.parent.parent.parent;

                if (CodeDisplay)
                    CodeDisplay.text = "";
            }
            else if (other.name == "X")
            {
                _Index = 0;
                for (int i = 0; i < _CurrentCode.Length; i++)
                    _CurrentCode[i] = null;

                if (CodeDisplay)
                    CodeDisplay.text = "";
            }
            else if (_Index < _CurrentCode.Length)
            {
                try
                {
                    int number = int.Parse(other.name);
                    if (number >= 0 && number < 10)
                    {
                        _CurrentCode[_Index++] = other.gameObject;

                        if (CodeDisplay)
                            CodeDisplay.text += number;
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