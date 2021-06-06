using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesTake : MonoBehaviour
{
    private DisplayImage currentDisplay;
    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    private void Update()
    {
        if (Dresser.isOpen==false || currentDisplay.CurrentState == DisplayImage.State.normal || GameObject.Find("dresserInView") == null)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (Dresser.isOpen == true)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
