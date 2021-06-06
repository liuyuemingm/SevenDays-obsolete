using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private DisplayImage currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    void Update() //zoom in if hit interactable object
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 1000);

            if (hit && hit.transform.tag.Equals("Interactable"))
            {
                hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
            }
        }
    }

}
