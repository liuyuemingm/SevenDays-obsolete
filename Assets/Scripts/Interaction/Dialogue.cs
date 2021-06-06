
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour, IInteractable
{
    public GameObject text;
    public bool isMailbox;
    public bool isDoor;
    public static bool DressOn;
    public static bool MaskOn;
    public static bool Invitation;


    private void Start()
    {
        GetComponent<Image>().enabled = false;
        text.SetActive(false);
    }

    private void Update()
    {
        hideText();

    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (currentDisplay.CurrentState == DisplayImage.State.normal && !isDoor || isMailbox)
        {
            text.SetActive(true);
            GetComponent<Image>().enabled = true;
        }else if (isDoor)
        {
            if (DressOn && MaskOn && Invitation)
            {
                FinalCutscene.doorClicked = true;
            }
            else
            {
                text.SetActive(true);
                GetComponent<Image>().enabled = true;
            }
        }

       
    }

    private void hideText()
    {
        if (Input.GetMouseButtonDown(0) && text.activeSelf)
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 500);
            if (hit.collider != GetComponent<BoxCollider2D>())
            {
                text.SetActive(false);
                GetComponent<Image>().enabled = false;
            }
            
        }
    }
}
