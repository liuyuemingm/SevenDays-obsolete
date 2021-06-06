using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseInventoryItem : MonoBehaviour, IInteractable
{
    public string UnlockItem;
    private GameObject inventory;
    public enum Apply { None, Bowtie, VeryDizzy, Dizzy, Mask, Dress, Mailbox, 
                        Blancket, Gloves, Letter, Knife, Invitation, Door }
    public Apply Application;

    private void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSelectedSlot != null)
        {
            if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).
                GetComponent<Image>().sprite.name == UnlockItem)
            {
                inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
                inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/transparent480");
                additionalBehaviour();
            }
        }
    }

    private void additionalBehaviour()
    {
        if (Application == Apply.Bowtie)
            Planck.ButterflyAquired = true;
        else if (Application == Apply.Mailbox)
            MailBox.StringAqiured = true;
        else if (Application == Apply.VeryDizzy)
            Destroy(GameObject.Find("VeryDizzy"));
        else if (Application == Apply.Dizzy)
        {
            GameObject.Find("Mmask").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("Mdress").GetComponent<BoxCollider2D>().enabled = true;
            Destroy(GameObject.Find("Dizzy"));
        }
        else if (Application == Apply.Blancket)
            Shadow.backgroundChange = true;
        else if (Application == Apply.Gloves)
        {
            GlovesUse.left.SetActive(true);
            GlovesUse.right.SetActive(true);
            Shadow.GlovesAquired = true;
        }
        else if (Application == Apply.Mask)
        {
            GameObject.Find("Mmask").GetComponent<SpriteRenderer>().enabled = true;
            Dialogue.MaskOn = true;
        }

        else if (Application == Apply.Dress)
        {
            GameObject.Find("Mdress").GetComponent<Image>().enabled = true;
            Dialogue.DressOn = true;
        }
        else if (Application == Apply.Mailbox)
            MailBox.StringAqiured = true;
        else if (Application == Apply.Letter)
            Desk.Desk1.SetActive(true);
        else if (Application == Apply.Knife)
        {
            Desk.Desk2.SetActive(true);
        }
        else if (Application == Apply.Invitation)
            Desk.Desk3.SetActive(true);
        else if (Application == Apply.Door)
        { }



    }
}
