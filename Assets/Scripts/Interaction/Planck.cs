using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planck : MonoBehaviour, IInteractable
{
    public GameObject Pill;
    public GameObject BowTie;
    public static bool ButterflyAquired;
    private SpriteRenderer SR;

    public void Interact(DisplayImage currentDisplay)
    {
        if (!ButterflyAquired)
        {
            if (SR.enabled == true)
                SR.enabled = false;
            else
                SR.enabled = true;
        }
    }

    private void Start()
    {
        Pill.SetActive(false);
        BowTie.SetActive(false);
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
        ButterflyAquired = false;
    }

    private void Update()
    {
        if(ButterflyAquired && Pill != null)
        {
            SR.enabled = false;
            Pill.SetActive(true);
            BowTie.SetActive(true);
        }

    }


}
