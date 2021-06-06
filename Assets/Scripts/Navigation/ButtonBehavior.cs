using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public enum ButtonId { roomChange, returnButton}

    public ButtonId ThisButttonId;
    private DisplayImage currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    private void Update()
    {
        HideDisplay();
        Display();
    }

    void HideDisplay() // hides a button and disable it when not in use
    {
        if (currentDisplay.CurrentState == DisplayImage.State.normal && ThisButttonId == ButtonId.returnButton)
        {
            GetComponent<Image>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Button>().enabled = false;
        }

        if (currentDisplay.CurrentState != DisplayImage.State.normal && ThisButttonId == ButtonId.roomChange)
        {
            GetComponent<Image>().enabled = false;
            GetComponent<Button>().enabled = false;
        }

        if (currentDisplay.CurrentState == DisplayImage.State.cutscene && ThisButttonId == ButtonId.returnButton)
        {
            GetComponent<Image>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Button>().enabled = false;
        }
        if (currentDisplay.CurrentState == DisplayImage.State.zoom && ThisButttonId == ButtonId.returnButton)
        {
            GetComponent<Image>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Button>().enabled = false;
        }
    }

    void Display() 
    {
        if (currentDisplay.CurrentState == DisplayImage.State.changeView && ThisButttonId == ButtonId.returnButton)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Button>().enabled = true;
        }

        if (currentDisplay.CurrentState == DisplayImage.State.normal && ThisButttonId == ButtonId.roomChange)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Button>().enabled = true;
        }
    }
}
