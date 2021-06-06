using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public enum State {On, Off };

    public int lampID;
    private DisplayImage currentDisplay;
    private State lampState; // not for lamp 1
    public static bool LampOneIsOn;
    private static bool LampThreeIsOn;
    private GameObject lamp1Wall1;
    private GameObject lamp1Wall2;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        lampState = State.Off;
        LampOneIsOn = false;
        LampThreeIsOn = false;
        lamp1Wall1 = GameObject.Find("lamp1Wall1");
        lamp1Wall2 = GameObject.Find("lamp1Wall2");
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentDisplay.CurrentState != DisplayImage.State.normal) // disallow interacting with curtain when view changed
            //this.enabled = false;

        if (lampID == 1)
        {
            if (LampOneIsOn)
            {
                lamp1Wall1.GetComponent<SpriteRenderer>().enabled = true;
                lamp1Wall2.GetComponent<SpriteRenderer>().enabled = true;
                RoomDivider.lightOn = true;
            }
            else
            {
                lamp1Wall1.GetComponent<SpriteRenderer>().enabled = false;
                lamp1Wall2.GetComponent<SpriteRenderer>().enabled = false;
                RoomDivider.lightOn = false;
            }
        }
        else
        {
            if (lampState == State.On)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (lampState == State.Off)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
            
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (lampID == 1)
        {
            if (LampOneIsOn)
            {
                LampOneIsOn = false;
            }
            else
            {
                LampOneIsOn = true;
            }
                
        }
        else if(lampID == 3)
        {
            if (LampThreeIsOn)
            {
                LampThreeIsOn = false;
                lampState = State.Off;
                Guitar.lightOn = false;
                
            }
            else
            {
                LampThreeIsOn = true;
                lampState = State.On;
                Guitar.lightOn = true;            
            }

        }
        else
        {
            if (lampState == State.On)
                lampState = State.Off;
            else
                lampState = State.On;
        }
        
    }
}
