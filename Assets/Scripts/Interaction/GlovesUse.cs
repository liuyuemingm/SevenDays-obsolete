using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesUse : MonoBehaviour
{
    public static GameObject left;
    public static GameObject right;
    public static byte leftChildInView; // the order in the hierarchy, not the name
    public static byte rightChildInView; // the order in the hierarchy, not the name


    private void Start()
    {
        left = transform.Find("left").gameObject;
        right = transform.Find("right").gameObject;
        SetActive();
        left.SetActive(false);
        right.SetActive(false);
        leftChildInView = 0;
        rightChildInView = 0;

    } // setting true was achieved via UseInventoryItem

    /** make the children not in view inactive, and vice versa
     */
    private void SetActive()
    {
        left.transform.GetChild(leftChildInView).gameObject.SetActive(true);
        right.transform.GetChild(rightChildInView).gameObject.SetActive(true);

        for (byte b = 0; b < 5; b++)
            if (b != leftChildInView)
                left.transform.GetChild(b).gameObject.SetActive(false);

        for (byte b = 0; b < 6; b++)
            if (b != rightChildInView)
                right.transform.GetChild(b).gameObject.SetActive(false);
    }

    private void Update()
    {
        SetActive();
    }

}
