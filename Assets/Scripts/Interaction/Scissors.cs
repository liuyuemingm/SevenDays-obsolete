using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scissors : MonoBehaviour, IInteractable
{
    [SerializeField] private Image scissorRemain;
    [SerializeField] private GameObject scissorsTake;
    [SerializeField] private Image scissors;
    private bool interacted;

    void Start()
    {
        scissors.enabled = true;
        scissorRemain.enabled = false;
        scissorsTake.SetActive(false);
    }

    public void Interact(DisplayImage notUsing)
    {
        if (!interacted)
        {
            scissors.enabled = false;
            scissorsTake.SetActive(true);
            scissorRemain.enabled = true;
            interacted = true;
        }
        
        
    }
}
