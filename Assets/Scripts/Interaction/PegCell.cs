using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegCell : MonoBehaviour
{
    public byte ID;
    public enum State { vacant, occupied, forbidden, potential }
    public State CellState;
    public static PegCell currentCell;
    public static PegCell previousCell;
    private static bool firstTime;
    private static Color color = new Color(0.8f, 0.6f, 0.6f, 1);
    private static Color colorBack = new Color(1, 1, 1, 1);

    private void Start()
    {
        CellState = State.forbidden;
        currentCell = null;
        previousCell = null;
        firstTime = true;
    }

    private void Update()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + CellState.ToString());
        if (this==currentCell)
            this.GetComponent<Image>().color = color;
        else
            this.GetComponent<Image>().color = colorBack;

    }

    public static void selectCell() // assign selectedCell to the on the player clicked
    {
        //if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 500);

            if (hit && hit.transform.tag.Equals("Player") && hit.transform.GetComponent<PegCell>().CellState!=PegCell.State.forbidden)
            {
                if (firstTime)
                {
                    previousCell = hit.transform.GetComponent<PegCell>();
                    currentCell = previousCell;
                    firstTime = false;
                }
                else
                {
                    previousCell = currentCell;
                    currentCell = hit.transform.GetComponent<PegCell>();
                }
            }
        }
    }

}
