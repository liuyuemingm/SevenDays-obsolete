using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * display image depending on whether light is on
 */
public class RoomDivider : MonoBehaviour
{
    private DisplayImage currentDisplay;
    public static bool lightOn;
    public GameObject Display;

    private void Start()
    {
        Display = transform.Find("tearAlready").gameObject;
        Display.SetActive(false);
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    private void Update()
    {
        if (lightOn)
            Display.SetActive(true);
        else
            Display.SetActive(false); 
    }

}
