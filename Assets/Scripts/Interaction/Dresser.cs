using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dresser : MonoBehaviour,IInteractable
{
    public GameObject gloves;
    public static bool isOpen;
    
    public void Interact(DisplayImage currentDisplay)
    {
        if (isOpen)
            isOpen = false;
        else
            isOpen = true;
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        
    }

    private void Update()
    {
        if (isOpen)
            GetComponent<SpriteRenderer>().enabled = true;
        else
            GetComponent<SpriteRenderer>().enabled = false;
    }

}
