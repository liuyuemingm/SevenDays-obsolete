using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;
    public enum property { usable, displayable, empty};
    public property ItemProperty { get; set; }
    public string BigPicture; 
    private DisplayImage currentDisplay;


    private void Start()
    {
        inventory = GameObject.Find("Inventory");
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentDisplay.CurrentState != DisplayImage.State.cutscene)
        {
            inventory.GetComponent<Inventory>().previousSelectedSlot = inventory.GetComponent<Inventory>().currentSelectedSlot;
            inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;
        }
        
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (property)orderNumber;
        this.BigPicture = displayImage;
    }

    public void DisplayItem()
    {
        inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
        inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Inventory Items/" + BigPicture);

        
    }
}
