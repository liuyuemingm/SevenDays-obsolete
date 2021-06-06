using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightstand : MonoBehaviour, IInteractable
{
    private GameObject blanket;

    public void Interact(DisplayImage currentDisplay)
    {
        if (GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            if (blanket != null)
                blanket.SetActive(false);
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            if (blanket != null)
                blanket.SetActive(true);
        }
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        try { blanket = transform.Find("blanket").gameObject; }
        catch (NullReferenceException) { }
        if (blanket != null)
            blanket.SetActive(false);
        
    }
}
