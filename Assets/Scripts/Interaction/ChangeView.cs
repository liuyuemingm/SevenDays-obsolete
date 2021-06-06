using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* open the image corresponding to the object to inspect
 */
public class ChangeView : MonoBehaviour, IInteractable
{
    private DisplayImage currentDisplay;
    [SerializeField] private GameObject customObject;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //customImage.enabled = false;
        customObject.SetActive(false);
        
    }

    public void Interact(DisplayImage currentDisplay)
    {
        //customImage.enabled = true;
        if (currentDisplay.CurrentState == DisplayImage.State.normal)
        {
            customObject.SetActive(true);
            currentDisplay.CurrentState = DisplayImage.State.changeView;
        }
    }

    private void Update()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.normal)
            customObject.SetActive(false);
        //customImage.enabled = false;
        // if job done, destroy object
    }



}
