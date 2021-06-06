using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Localizer : MonoBehaviour
{
    public string HintKey { get; set; }
    public string Key;
    private Text textField;
    private TextMeshProUGUI TMPField;
    public static bool LanguageIsEnglish;
    private bool TextIsEnglish;

    [SerializeField]
    public TMP_FontAsset EnglishFont;
    [SerializeField]
    public TMP_FontAsset ChineseFont;

    
    public enum Property { PlainText, TMP, HintSystem}
    public Property property;

    private void Awake()
    {
        
        if (property == Property.PlainText)
        {
            textField = GetComponent<Text>();
        }
        else if (property == Property.TMP)
        {
            TMPField = GetComponent<TextMeshProUGUI>();
        }
        else if (property == Property.HintSystem)
        {
            textField = GetComponent<Text>();
        }

        TextIsEnglish = true;
        
    }

    private void PlainTextLocalizer()
    {
        if (LanguageIsEnglish && !TextIsEnglish)
        { 
            textField.text = LocalsData.English[Key].ToString();
            TextIsEnglish = true;
        }
        else if (!LanguageIsEnglish && TextIsEnglish)
        {
            textField.text = LocalsData.Chinese[Key].ToString();
            TextIsEnglish = false;
        }

    }

    private void TMPLocalizer()
    {
        if (LanguageIsEnglish && !TextIsEnglish)
        {
            TMPField.font = EnglishFont;
            TMPField.text = LocalsData.English[Key].ToString();
            TextIsEnglish = true;
        }
        else if (!LanguageIsEnglish && TextIsEnglish)
        {
            TMPField.font = ChineseFont;
            TMPField.text = LocalsData.Chinese[Key].ToString();
            TextIsEnglish = false;
        }

    }

    private void HintSystemLocalizer()
    {
        if (HintKey == null)
            return;

        if (LanguageIsEnglish)
        {
            
            textField.text = LocalsData.English[HintKey].ToString();
            TextIsEnglish = true;
        }
        else if (!LanguageIsEnglish)
        {
           
            textField.text = LocalsData.Chinese[HintKey].ToString();
            TextIsEnglish = false;
        }
        
    }

    private void Update()
    {
        if (property == Property.PlainText)
        {
            PlainTextLocalizer();
        }
        else if (property == Property.TMP)
        {
            TMPLocalizer();
        }
        else if (property == Property.HintSystem)
        {
            HintSystemLocalizer();
        }
        Languages.isChinese = !LanguageIsEnglish;
    }

    
}
