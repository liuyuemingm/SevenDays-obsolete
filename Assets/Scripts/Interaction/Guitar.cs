using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guitar : MonoBehaviour
{
    public static bool lightOn;
    private static short[] Sequence0 = { 5, 5, 3, 2, 3, 8 };
    private static short[] Sequence1 = { 2, 3, 5, 3, 2 };
    private static short[] Sequence2 = { 5, 5, 3, 2, 3, 7 };
    private static short[] Sequence3 = { 2, 3, 5, 2, 1 };
    public static short[] CurrentSquence;
    public static GameObject GuitarString;
    public static GameObject Note;
    private static bool entireNotePlayed;
    private static Sprite Dark;
    private static Sprite Bright;
    private static Sprite Break;
    public static byte Index;

    void Start()
    {
        lightOn = false;
        CurrentSquence = Sequence0;
        GuitarString = GameObject.Find("guitarString");
        GuitarString.SetActive(false);
        // assign Note to the corresponding inventory slot when the musical note is aquired
        
        Dark = Resources.Load<Sprite>("Inventory Items/guitarDark");
        Bright = Resources.Load<Sprite>("Inventory Items/guitarBright");
        Break = Resources.Load<Sprite>("Inventory Items/guitarBreak");
        entireNotePlayed = false;
    }

    private void Update() // change display guitar shade - dark or bright
    {
        if (lightOn && !entireNotePlayed)
        {
            GetComponent<Image>().sprite = Bright;
        }else if (!lightOn && !entireNotePlayed)
        {
            GetComponent<Image>().sprite = Dark;
        }else if (entireNotePlayed)
        {
            GetComponent<Image>().sprite = Break;
        }
    }

    /* precondition: the single note played matches the next number in the current sequence
     * increment the index ahead by one in the current sequence or move to the next sequence
     */
    public static void EnterCorrect()   
    {
        if (!entireNotePlayed && Note != null)
        {
            Index++;
            if (Index == CurrentSquence.Length)
                NextSquence();
        }
    }

    /* precondition: the sequence is correct
     */
    public static void NextSquence()
    {
        if (CurrentSquence == Sequence0)
        {
            CurrentSquence = Sequence1;
            Note.GetComponent<Slot>().BigPicture = "noteDisplay1";
            Index = 0;
        } 
        else if (CurrentSquence == Sequence1)
        {
            CurrentSquence = Sequence2;
            Note.GetComponent<Slot>().BigPicture = "noteDisplay2";
            Index = 0;
        }
        else if (CurrentSquence == Sequence2)
        {
            CurrentSquence = Sequence3;
            Note.GetComponent<Slot>().BigPicture = "noteDisplay3";
            Index = 0;
        }
        else if (CurrentSquence == Sequence3)//
        {
            entireNotePlayed = true;
            GuitarString.SetActive(true);
            Note.GetComponent<Slot>().ItemProperty = Slot.property.empty;
            Note.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/transparent480");
            //Debug.Log("play break sound");
            FindObjectOfType<AudioManager>().PlaySound("Note wrong");
        }
    }

    /*
     * move the index back to the beginning of the current
     */
    public static void EnterWrong()
    {
        if (!entireNotePlayed && Note != null)
        {
            
            Index = 0;
        }
    }
}
