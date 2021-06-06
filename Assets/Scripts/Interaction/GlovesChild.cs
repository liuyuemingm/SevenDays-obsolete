using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesChild : MonoBehaviour, IInteractable
{
    public enum Side {Left, Right}
    public Side side;

    public void Interact(DisplayImage currentDisplay)
    {
        if (side == Side.Left)
            LeftIncrement();
        else if (side == Side.Right)
            RightIncrement();

        if (GlovesUse.left.transform.GetChild(GlovesUse.leftChildInView).name == 
            GlovesUse.right.transform.GetChild(GlovesUse.rightChildInView).name &&
            GlovesUse.left.transform.GetChild(GlovesUse.leftChildInView).name == Shadow.BackgroundID.ToString())
            Shadow.backgroundChange = true;
    }


    private void LeftIncrement()
    {
        if (GlovesUse.leftChildInView == 4)
            GlovesUse.leftChildInView = 0;
        else
            GlovesUse.leftChildInView ++;
    }

    private void RightIncrement()
    {
        if (GlovesUse.rightChildInView == 5)
            GlovesUse.rightChildInView = 0;
        else GlovesUse.rightChildInView ++;
    }
}
