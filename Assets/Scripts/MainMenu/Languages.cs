using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Languages : MonoBehaviour
{
    public static bool isChinese { get; set; }
    public TMP_Text[] EnglishTextList;
    public TMP_Text[] ChineseTextList;
    public GameObject Toggle;
    private static bool toggleRight;

    // all Chinese TMP component is set disabled by default in the inspector

    // change language in main menu
    public void SwitchLanguage()
    {
        if (isChinese)
        {
            isChinese = false;
            foreach (TMP_Text TMP in EnglishTextList)
            {
                TMP.GetComponent<TextMeshProUGUI>().enabled = true;
            }

            foreach (TMP_Text TMP in ChineseTextList)
            {
                TMP.GetComponent<TextMeshProUGUI>().enabled = false;
            }

        }
        else
        {
            isChinese = true;
            foreach (TMP_Text TMP in EnglishTextList)
            {
                TMP.GetComponent<TextMeshProUGUI>().enabled = false;
            }

            foreach (TMP_Text TMP in ChineseTextList)
            {
                TMP.GetComponent<TextMeshProUGUI>().enabled = true;
            }
        }
    }

    public void ToggleSwitcher()
    {
        if (toggleRight && !isChinese)
        {
            // flip toggle to the left
            toggleRight = false;
            Toggle.GetComponent<Animator>().Play("ToggleToLeft");
            Toggle.GetComponent<RectTransform>().rotation.Set(0, 0, 180, 0);
        }else if (!toggleRight && isChinese)
        {
            // flip toggle to the right
            toggleRight = true;
            Toggle.GetComponent<Animator>().Play("ToggleToRight");
            Toggle.GetComponent<RectTransform>().rotation.Set(0, 0, 0, 0);
        }
    }

    private void Update()
    {
        ToggleSwitcher();
        Localizer.LanguageIsEnglish = !isChinese;
    }


}
