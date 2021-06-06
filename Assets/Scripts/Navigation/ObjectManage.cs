using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManage : MonoBehaviour
{
    private DisplayImage currentDisplay;

    public GameObject[] ObjectsToManage;
    public GameObject[] UIRenderObjects;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        RenderUI();
    }

    private void Update()
    {
        ManageObjects();
    }

    void ManageObjects() // avoid interacting with objects currently shouldn't be active
    {
        for (int i= 0; i< ObjectsToManage.Length; i++)
        {
            if (ObjectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                ObjectsToManage[i].SetActive(true);
            }
            else
            {
                ObjectsToManage[i].SetActive(false);
            }
        }
    }

    void RenderUI()
    {
        for(int i=0; i< UIRenderObjects.Length; i++)
        {
            UIRenderObjects[i].SetActive(false);
        } 
    }

   
}
