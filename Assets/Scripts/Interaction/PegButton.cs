using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegButton : MonoBehaviour
{
    public GameObject Butterfly;
    private GameObject PegTable;
    public bool ButtonNext;

    private void Start()
    {
        if (ButtonNext)
            GetComponent<Button>().interactable = false;
        Butterfly.SetActive(false);
        PegTable = GameObject.Find("PegTable");
    }

    private void Update()
    {
        if (ButtonNext)
        {
            if (PegSolitaire.ThisLevelDone)
                GetComponent<Button>().interactable = true;
            else
                GetComponent<Button>().interactable = false;
        }
    }


    public void Next()
    {
        if (PegSolitaire.ThisLevelDone )
        {
            if (PegSolitaire.level < 3)
            {
                PegSolitaire.ThisLevelDone = false;
                PegSolitaire.level++;
                PegTable.GetComponent<PegSolitaire>().InitializeLevel();
            }
            else
            {
                PegSolitaire.ThisLevelDone = false;
                if (Butterfly != null)
                Butterfly.SetActive(true);
            }
        }
    }

    public void StartOver()
    {
        PegTable.GetComponent<PegSolitaire>().InitializeLevel();
    }
}
