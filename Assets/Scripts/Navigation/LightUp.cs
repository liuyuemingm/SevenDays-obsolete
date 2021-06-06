using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightUp : MonoBehaviour
{

    void Start()
    {
        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Curtain.CurtainOn)
        {
            GetComponent<Image>().enabled = true;
            GameObject.Find("hanger").GetComponent<Shadow>().roomBright = true;
        }
        else
        { 
            GetComponent<Image>().enabled = false;
            GameObject.Find("hanger").GetComponent<Shadow>().roomBright = false;
        }

    }
}
