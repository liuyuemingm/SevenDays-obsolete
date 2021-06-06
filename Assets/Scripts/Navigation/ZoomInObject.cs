using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public float ZoomRatio;

    //zoom in
    public void Interact(DisplayImage currentDisplay)
    {
        Camera.main.orthographicSize *= ZoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);
        gameObject.layer = 2; // restric the num of zooms
        currentDisplay.CurrentState = DisplayImage.State.zoom;

    }

    
}
