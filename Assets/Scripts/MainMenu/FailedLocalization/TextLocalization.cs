using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocalization : MonoBehaviour
{
    //TextMeshProUGUI textField;
    Text textField;
    public string key;


    private void changeLanguage()
    {
        textField = GetComponent<Text>();
        string value = LocalizationSystem.GetLocalizedValue(key);
        textField.text = value;
    
    }

    private void Update()
    {
        changeLanguage();
    }
}
