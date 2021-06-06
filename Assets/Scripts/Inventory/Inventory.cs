using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }
    private GameObject slots;
    public GameObject itemDisplayer { get; private set; }
    private DisplayImage currentDisplay;
    private DisplayImage.State previousState;

    private void Start()
    {
        InitializeInventory();
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        previousState = DisplayImage.State.normal;
    }
    private void Update()
    {
        HideDisplay();
        SelectSlot(currentDisplay);
    }

    void InitializeInventory()
    {
        slots = GameObject.Find("Slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        foreach(Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/transparent480");
        }
    }

    private static Color color = new Color(0.9f, 0.4f, 0.6f, 1);
    private static Color colorBack = new Color(1, 1, 1, 1);

    void SelectSlot(DisplayImage currentDisplay) // highlight the slot if selected
    {
       
            foreach (Transform slot in slots.transform)
            {
                if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
                {
                    slot.GetComponent<Image>().color = color;
                }
                else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
                {
                    if (currentDisplay.CurrentState != DisplayImage.State.zoom)
                        previousState = currentDisplay.CurrentState;

                    slot.GetComponent<Image>().color = color;
                    currentDisplay.CurrentState = DisplayImage.State.zoom;
                    slot.GetComponent<Slot>().DisplayItem();

                }
                else
                {
                    slot.GetComponent<Image>().color = colorBack;
                }
            }
        
    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && currentSelectedSlot!=null)//&& !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject)
        {
                if (currentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
                {
                    itemDisplayer.SetActive(false);
                    currentSelectedSlot = previousSelectedSlot;
                    currentDisplay.CurrentState = previousState;
                }
            
        }
    }

}
