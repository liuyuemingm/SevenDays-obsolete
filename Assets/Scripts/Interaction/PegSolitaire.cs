using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PegSolitaire : MonoBehaviour
{
    public static byte level;
    public static bool ThisLevelDone;
    private static short marblesRemain; // each level remquire
    private static PegCell[,] list = new PegCell[4, 2];
    private bool firstInitializationDone;

    private void Start()
    {
        InitializeCellID();
        level = 0;
        ThisLevelDone = false;
    }
    private void Update()
    {
        if (!firstInitializationDone)
        {
            InitializeLevel();
            firstInitializationDone = true;
        }

        if ((level == 0 || level == 1) && marblesRemain == 1)
            ThisLevelDone = true;
        if (level == 2 && marblesRemain <= 3)
            ThisLevelDone = true;
        if (level == 3 && marblesRemain <= 5)
            ThisLevelDone = true;

        if (Input.GetMouseButtonDown(0))
        {
            PegCell.selectCell();
            Jump();
        }
    }
   
    private void InitializeCellID()
    {
        for (byte b=0; b<81; b++)
        {
            transform.GetChild(b).GetComponent<PegCell>().ID = b;
        }

    }
    public void InitializeLevel()
    {
        if (level == 0)
        {
            Level_0();
        }else if (level == 1)
        {
            Level_1();
        }else if (level == 2)
        {
            GameObject.Find("PegRule2").GetComponent<TextMeshProUGUI>().text = "3";
            Level_2();
        }else if (level == 3)
        {
            GameObject.Find("PegRule2").GetComponent<TextMeshProUGUI>().text = "5";
            Level_3();
        }
    }
    private void Level_0()
    {
        marblesRemain = 3;

        transform.GetChild(49).GetComponent<PegCell>().CellState = PegCell.State.vacant;
        transform.GetChild(50).GetComponent<PegCell>().CellState = PegCell.State.vacant;

        byte[] occupiedList = { 31, 40, 48};
        foreach (byte b in occupiedList)
        {
            transform.GetChild(b).GetComponent<PegCell>().CellState = PegCell.State.occupied;
        }
    }
    private void Level_1()
    {
        marblesRemain = 7;

        transform.GetChild(49).GetComponent<PegCell>().CellState = PegCell.State.forbidden;
        transform.GetChild(50).GetComponent<PegCell>().CellState = PegCell.State.forbidden;
        transform.GetChild(22).GetComponent<PegCell>().CellState = PegCell.State.vacant;

        byte[] occupiedList = {29, 30, 31, 39, 40, 41, 48 };
        foreach (byte b in occupiedList)
            transform.GetChild(b).GetComponent<PegCell>().CellState = PegCell.State.occupied;
    } 
    private void Level_2()
    {
        marblesRemain = 16;

        transform.GetChild(40).GetComponent<PegCell>().CellState = PegCell.State.vacant;
        transform.GetChild(48).GetComponent<PegCell>().CellState = PegCell.State.forbidden;

        byte[] occupiedList = { 20, 21, 22, 29, 30, 31, 38, 39, 41, 42, 49, 50, 51, 58, 59, 60 };
        foreach (byte b in occupiedList)
            transform.GetChild(b).GetComponent<PegCell>().CellState = PegCell.State.occupied;
    } 
    private void Level_3()
    {
        marblesRemain = 32;

        transform.GetChild(20).GetComponent<PegCell>().CellState = PegCell.State.forbidden;
        transform.GetChild(60).GetComponent<PegCell>().CellState = PegCell.State.forbidden;

        byte[] occupiedList = { 12, 13, 14, 21, 22, 23, 57, 58, 59, 66, 67, 68 };
        foreach (byte b in occupiedList)
            transform.GetChild(b).GetComponent<PegCell>().CellState = PegCell.State.occupied;

        for (byte b=0; b<7; b++)
        {
            transform.GetChild(b+28).GetComponent<PegCell>().CellState = PegCell.State.occupied;
            transform.GetChild(b+37).GetComponent<PegCell>().CellState = PegCell.State.occupied;
            transform.GetChild(b+46).GetComponent<PegCell>().CellState = PegCell.State.occupied;
        }

        transform.GetChild(40).GetComponent<PegCell>().CellState = PegCell.State.vacant;

    }

    /*
     * return a list of cell pairs the marble can jump over
     * pair: jump-ove -- land-on
     * precodition: the current state is occupied, 
     * the jump-over cell is occupied, and the land-on cell is vacant
     * highlight possible landing cell
     */
    private void JumpList() 
    {
        
        PegCell p = PegCell.currentCell;
        if (p!=null && p.CellState == PegCell.State.occupied)
        {
            for (byte i = 0; i < 4; i++)
                if (list[i, 1] != null && list[i, 1].CellState == PegCell.State.potential)
                    list[i, 1].CellState = PegCell.State.vacant;
            //empty the list
            for (byte i = 0; i < 4; i++)
                for (byte j = 0; j < 2; j++)
                    list[i, j] = null;

            byte b = p.ID;

            if (b > 18) // there is at leat two rows above it
            {
                PegCell oneAbove = transform.GetChild(b - 9).GetComponent<PegCell>();
                PegCell twoAbove = transform.GetChild(b - 18).GetComponent<PegCell>();
                if (oneAbove.CellState == PegCell.State.occupied 
                    && twoAbove.CellState == PegCell.State.vacant)
                {
                    list[0, 0] = oneAbove;
                    list[0, 1] = twoAbove;
                    twoAbove.CellState = PegCell.State.potential;
                }
            }
            if (b % 9 > 1) // there is at leat two columns to the left
            {
                PegCell oneLeft = transform.GetChild(b - 1).GetComponent<PegCell>();
                PegCell twoLeft = transform.GetChild(b - 2).GetComponent<PegCell>();
                if (oneLeft.CellState == PegCell.State.occupied
                    && twoLeft.CellState == PegCell.State.vacant)
                {
                    list[1, 0] = oneLeft;
                    list[1, 1] = twoLeft;
                    twoLeft.CellState = PegCell.State.potential;
                }
            }
            if (b % 9 < 7) // there are at least two columns right to it
            {
                PegCell oneRight = transform.GetChild(b + 1).GetComponent<PegCell>();
                PegCell twoRight = transform.GetChild(b + 2).GetComponent<PegCell>();
                if (oneRight.CellState == PegCell.State.occupied
                    && twoRight.CellState == PegCell.State.vacant)
                {
                    list[2, 0] = oneRight;
                    list[2, 1] = twoRight;
                    twoRight.CellState = PegCell.State.potential;
                }
            }
            if (b < 62) // there are at leat two rows below it
            {
                PegCell oneBelow = transform.GetChild(b + 9).GetComponent<PegCell>();
                PegCell twoBelow = transform.GetChild(b + 18).GetComponent<PegCell>();
                if (oneBelow.CellState == PegCell.State.occupied
                    && twoBelow.CellState == PegCell.State.vacant)
                {
                    list[3, 0] = oneBelow;
                    list[3, 1] = twoBelow;
                    twoBelow.CellState = PegCell.State.potential;
                }
            }
        } else if (p != null && p.CellState == PegCell.State.vacant)
        {
            for (byte i = 0; i < 4; i++)
                if (list[i, 1] != null && list[i, 1].CellState == PegCell.State.potential)
                    list[i, 1].CellState = PegCell.State.vacant;

            for (byte i = 0; i < 4; i++)
                for (byte j = 0; j < 2; j++)
                    list[i, j] = null;
        }



    }


    /* 
     * jump to the spot the player selected
     * if the spot is on the left, then set b-1 to vacant,
     * set b-2 to occupied, decrease the num of remaining marbles by one
     */
    private void Jump() 
    {
        JumpList();

        for (byte b=0; b<4; b++)
        {
            if (PegCell.previousCell != null && PegCell.currentCell == list[0, 1])
            {
                list[0, 1].CellState = PegCell.State.occupied;
                list[0, 0].CellState = PegCell.State.vacant;
                PegCell.previousCell.CellState = PegCell.State.vacant;
                marblesRemain--;
                for (byte i = 0; i < 4; i++)
                    if (list[i, 1] != null && list[i, 1].CellState == PegCell.State.potential)
                        list[i, 1].CellState = PegCell.State.vacant;
                break;
            }
            if (PegCell.previousCell != null && PegCell.currentCell.Equals(list[1, 1]))
            {
                list[1, 1].CellState = PegCell.State.occupied;
                list[1, 0].CellState = PegCell.State.vacant;
                PegCell.previousCell.CellState = PegCell.State.vacant;
                marblesRemain--;
                for (byte i = 0; i < 4; i++)
                    if (list[i, 1] != null && list[i, 1].CellState == PegCell.State.potential)
                        list[i, 1].CellState = PegCell.State.vacant;
                break;
            }
            if (PegCell.previousCell != null && PegCell.currentCell == list[2, 1])
            {
                list[2, 1].CellState = PegCell.State.occupied;
                list[2, 0].CellState = PegCell.State.vacant;
                PegCell.previousCell.CellState = PegCell.State.vacant;
                marblesRemain--;
                for (byte i = 0; i < 4; i++)
                    if (list[i, 1] != null && list[i, 1].CellState == PegCell.State.potential)
                        list[i, 1].CellState = PegCell.State.vacant;
                break;
            }
            if (PegCell.previousCell != null && PegCell.currentCell == list[3, 1])
            {
                PegCell.currentCell.CellState = PegCell.State.occupied;
                list[3, 0].CellState = PegCell.State.vacant;
                PegCell.previousCell.CellState = PegCell.State.vacant;
                marblesRemain--;
                for (byte i = 0; i < 4; i++)
                    if (list[i, 1] != null && list[i, 1].CellState == PegCell.State.potential)
                        list[i, 1].CellState = PegCell.State.vacant;
                break;
            }
        }
    }
}
