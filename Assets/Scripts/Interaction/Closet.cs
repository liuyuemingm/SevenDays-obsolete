using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
{
    public GameObject dress;

    public void Interact(DisplayImage currentDisplay)
    {
        if (GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            if (dress != null)
                dress.SetActive(false);
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            if (dress != null)
                dress.SetActive(true);
        }
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        dress.SetActive(false);

    }
}
