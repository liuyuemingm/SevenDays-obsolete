using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Curtain : MonoBehaviour, IInteractable

{
    public static bool CurtainOn;
    private DisplayImage currentDisplay;
    [SerializeField] private Image curtain;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        CurtainOn = false;
    }

    void Update()
    {
        if (currentDisplay.CurrentState != DisplayImage.State.normal) // disallow interacting with curtain when view changed
            GetComponent<BoxCollider2D>().enabled = false;
        else
            GetComponent<BoxCollider2D>().enabled = true;

        if (CurtainOn) // display the curtain when curtainOn is true
            curtain.enabled = true;
        else
            curtain.enabled = false;

    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (CurtainOn)
            CurtainOn = false;
        else
            CurtainOn = true;
    }
}
