using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string DisplaySprite; // for display in the inventory (thumbnail)
    private GameObject InventorySlots;
    public enum Property{ usable, displayable};
    public Property itemProperty;
    public string DisplayImage; // for big picture (as opposed to thumbnail)

    private void Start()
    {
        InventorySlots = GameObject.Find("Slots");
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (this != null)
            ItemPickUp();
    }

    void ItemPickUp() //put <DisplaySprite> into the first empty slot
    {

        
        foreach(Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name 
                == "transparent480")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite 
                    = Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage);

                // additional behaviour
                if (DisplaySprite == "noteStore")
                {
                    Guitar.Note = slot.gameObject;
                    FindObjectOfType<AudioManager>().PlaySound("Tear paper");
                }

                if (DisplaySprite == "invitationStore")
                {
                    Dialogue.Invitation = true;
                }

                Destroy(gameObject);
                break;
            }
                
        }
    }

}
