using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInvitation : MonoBehaviour, IInteractable
{
    public void Interact(DisplayImage currentDisplay)
    {
        if (Desk.Desk3 != null)
            Desk.Desk3.SetActive(true);
    }
}
