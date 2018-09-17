using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class KeypadLock : MonoBehaviour {

    public Lockable Lock;
    public GameObject[] Code;
    public Text CodeDisplay;
    public char BlankChar = '0';
    private string InitialCodeText;

    public GameObject[] _CurrentCode;
    private int _Index = 0;

	// Use this for initialization
	void Start () {
        _CurrentCode = new GameObject[Code.Length];
        if (CodeDisplay)
        {
            CodeDisplay.text = "";
            for (int i = 0; i < Code.Length; i++)
                CodeDisplay.text += BlankChar;
            InitialCodeText = CodeDisplay.text;
        }
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
                CheckCode();

            else if (other.name == "X")
                ClearCode();

            else if (_Index < _CurrentCode.Length)
            {
                try
                {
                    int number = int.Parse(other.name);
                    if (number >= 0 && number < 10)
                    {
                        if (CodeDisplay)
                        {
                            StringBuilder code = new StringBuilder(CodeDisplay.text);
                            code[_Index] = other.name[0];
                            CodeDisplay.text = code.ToString();
                        }

                        _CurrentCode[_Index++] = other.gameObject;

                    }
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                }
            }
        }
    }

    public void ClearCode()
    {
        _Index = 0;
        for (int i = 0; i < _CurrentCode.Length; i++)
            _CurrentCode[i] = null;

        if (CodeDisplay)
            CodeDisplay.text = InitialCodeText;
    }

    public void CheckCode()
    {
        // If no numbers have been entered
        // Don't try comparing the code
        if (_Index == 0) return;

        for (int i = 0; i < _CurrentCode.Length; i++)
            if (_CurrentCode[i].name != Code[i].name) return;

        // If the code is correct
        Lock.Unlock();

        if (CodeDisplay)
            CodeDisplay.text = InitialCodeText;
    }
}