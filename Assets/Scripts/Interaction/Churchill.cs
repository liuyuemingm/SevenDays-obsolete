using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Churchill : MonoBehaviour, IInteractable
{
    public GameObject Pill;
    private bool pillIsVisible;

    private void Start()
    {
        Pill.SetActive(false);
        Pill.GetComponent<SpriteRenderer>().enabled = false;
        pillIsVisible = false;
    }
    public void Interact(DisplayImage currentDisplay)
    {
        if (!pillIsVisible && Pill != null)
        {
            Pill.SetActive(true);
            Pill.GetComponent<SpriteRenderer>().enabled = true;
            pillIsVisible = true;
        }
        
        else if (pillIsVisible && Pill != null)
        {
            Pill.SetActive(false);
            Pill.GetComponent<SpriteRenderer>().enabled = false;
            pillIsVisible = false;
        }


    }
}
