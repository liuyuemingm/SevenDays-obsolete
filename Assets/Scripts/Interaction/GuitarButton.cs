using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuitarButton : MonoBehaviour, IInteractable
{
    public int ButtonID; // low-high combination is 7-2  8-3  1-5  lower 5 is 7 lower 6 is 8

    public void Interact(DisplayImage currentDisplay)
    {
        if (Guitar.Note == null)
        {
            FindObjectOfType<AudioManager>().PlaySound("Note wrong");
        }
        else
        {
            try
            {
                if (!Guitar.lightOn) //high
                {
                    if (ButtonID % 10 == Guitar.CurrentSquence[Guitar.Index])
                    {
                        FindObjectOfType<AudioManager>().PlaySound("Note " + (ButtonID % 10).ToString());
                        Guitar.EnterCorrect();
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().PlaySound("Note wrong");
                        Guitar.EnterWrong();
                    }
                }
                else if (Guitar.lightOn)
                {
                    if (ButtonID / 10 == Guitar.CurrentSquence[Guitar.Index])
                    {
                        FindObjectOfType<AudioManager>().PlaySound("Note " + (ButtonID / 10).ToString());
                        Guitar.EnterCorrect();
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().PlaySound("Note wrong");
                        Guitar.EnterWrong();
                    }

                }
            }
            catch (IndexOutOfRangeException)
            {
                FindObjectOfType<AudioManager>().PlaySound("Note wrong");
            }
        }
    }
}
