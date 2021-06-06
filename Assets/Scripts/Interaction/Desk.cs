using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    public static GameObject Desk1;
    public static GameObject Desk2;
    public static GameObject Desk3;

    private void Start()
    {
        Desk1 = GameObject.Find("desk1");
        Desk2 = GameObject.Find("desk2");
        Desk3 = GameObject.Find("desk3");
        Desk1.SetActive(false);
        Desk2.SetActive(false);
        Desk3.SetActive(false);
    }
}
