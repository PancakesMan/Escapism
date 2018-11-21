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
            // If there is a code display
            // set the text on the display
            CodeDisplay.text = "";
            for (int i = 0; i < Code.Length; i++)
                CodeDisplay.text += BlankChar;
            // Remember the empty code display string for later
            InitialCodeText = CodeDisplay.text;
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    // Detect keypad button press
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Button"))
        {
            // If you hit the tick button
            if (other.name == "O")
                CheckCode();

            // If you hit the X button
            else if (other.name == "X")
                ClearCode();

            // If you hit a number button
            else if (_Index < _CurrentCode.Length)
            {
                try
                {
                    // Get the number from the objects name
                    int number = int.Parse(other.name);
                    if (number >= 0 && number < 10)
                    {
                        if (CodeDisplay)
                        {
                            // Set the spot in the code display to the number entered
                            StringBuilder code = new StringBuilder(CodeDisplay.text);
                            code[_Index] = other.name[0];
                            CodeDisplay.text = code.ToString();
                        }
                        // Add the number to the current entered code
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
        // Reset index for next entered number
        _Index = 0;

        // Reset entered code array
        for (int i = 0; i < _CurrentCode.Length; i++)
            _CurrentCode[i] = null;

        /// Reset display text for the code
        if (CodeDisplay)
            CodeDisplay.text = InitialCodeText;
    }

    public void CheckCode()
    {
        // If no numbers have been entered
        // Don't try comparing the code
        if (_Index == 0) return;

        // If any number is not in the correct code array
        // Exit the functino early
        for (int i = 0; i < _CurrentCode.Length; i++)
            if (_CurrentCode[i].name != Code[i].name) return;

        // If the code is correct
        // Unlock the lock on the Lockable component
        Lock.Unlock();

        // Reset the display for the code
        if (CodeDisplay)
            CodeDisplay.text = InitialCodeText;
    }
}