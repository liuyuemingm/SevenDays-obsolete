using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageToggle : MonoBehaviour
{
    public static bool toggleLeft;

    private void Start()
    {
        toggleLeft = true;
    }

    public void ToggleSwitcher()
    {
        if (!toggleLeft && Localizer.LanguageIsEnglish)
        {
            // flip toggle to the left
            toggleLeft = true;
            GetComponent<Animator>().Play("ToggleToLeft");
            GetComponent<RectTransform>().rotation.Set(0, 0, 180, 0);
        }
        else if (toggleLeft && !Localizer.LanguageIsEnglish)
        {
            // flip toggle to the right
            toggleLeft = false;
            GetComponent<Animator>().Play("ToggleToRight");
            GetComponent<RectTransform>().rotation.Set(0, 0, 0, 0);
        }
    }

    private void Update()
    {
        ToggleSwitcher();
    }
}
