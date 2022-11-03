using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    public UnityEvent correctCodeEvent;



    public static KeypadController Instance;
    
    public Color defaultDisplayColor;
    public Image display;
    public TMPro.TextMeshProUGUI displayText;

    public int password = 1234;
    bool incorrectPassword;

    private void Start()
    {
        Instance = this;
        displayText.text = "";

        

    }

    public void NumberClicked(int number)
    {
        if (displayText.text.Length < 4)
        {
            if(!incorrectPassword)
            {
                displayText.text += number.ToString();
            }       
        }
    }
    
    public void FunctionClicked(string function)
    {
        switch(function)
        {
            case "Delete":
                if (displayText.text.Length > 0)
                {
                    displayText.text = displayText.text.Substring(0, displayText.text.Length - 1);
                }
                break;
            case "Clear":
                displayText.text = "";
                break;
            case "Enter":
                if (int.Parse(displayText.text) == password)
                {
                    Debug.Log("Password Correct");
                    displayText.text = "Correct";
                    CorrectPassword();
                }
                else
                {
                    Debug.Log("Password Incorrect");
                    StartCoroutine(IncorrectPassword());
                }
                break;
        }
    }


    public bool CorrectPassword()
    {
        displayText.text = "";
        correctCodeEvent.Invoke();
        return true;
    }


    IEnumerator IncorrectPassword()
    {
        incorrectPassword = true;
        display.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        display.color = defaultDisplayColor;
        yield return new WaitForSeconds(0.5f);
        display.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        display.color = defaultDisplayColor;
        displayText.text = "Incorrect";
        yield return new WaitForSeconds(0.5f);
        displayText.text = "";
        incorrectPassword = false;
    }


}
