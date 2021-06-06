using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** 
 * Change the background Image
 * Order of shadow: 0 default -> 1 rabbit -> 2 human -> 3 deer -> 4 mask
 */
public class Shadow : MonoBehaviour, IInteractable
{
    private DisplayImage currentDisplay;
   
    public GameObject BackgroundObject;
    public GameObject text;
    public static bool backgroundChange;
    public static short BackgroundID;
    public static bool GlovesAquired;
    public GameObject Mask;
    public bool roomBright;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        text.SetActive(false);
        BackgroundID = -1;
        Mask.SetActive(false);
        backgroundChange = false;
        GlovesAquired = false;
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (currentDisplay.CurrentState == DisplayImage.State.normal && roomBright)
        {
            BackgroundObject.SetActive(true);
            currentDisplay.CurrentState = DisplayImage.State.changeView;
        }else if (currentDisplay.CurrentState == DisplayImage.State.normal && !roomBright)
        {
            RoomDark();
        }

    }

    private void Update()
    {
        if (Mask!=null)
            HideRoomDark();

        if (currentDisplay.CurrentState == DisplayImage.State.normal)
            BackgroundObject.SetActive(false);

        if (GlovesAquired && BackgroundID == 0)
        {
            BackgroundID++;
            BackgroundObject.GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/Shadow/shadowBackground" + BackgroundID.ToString());
        }

        if (backgroundChange)
        {
            if (BackgroundID < 4)
            {
                backgroundChange = false;
                BackgroundID++;
                BackgroundObject.GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/Shadow/shadowBackground" + BackgroundID.ToString());
            }
            else
            {
                if (Mask != null)
                Mask.SetActive(true);
            }
        }
    }

    private void RoomDark()
    {
        text.SetActive(true);
    }

    private void HideRoomDark()
    {
        if (Input.GetMouseButtonDown(0) && text.activeSelf)
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 500);
            if (hit.collider != GetComponent<BoxCollider2D>())
            {
                text.SetActive(false);
            }

        }
    }
}
