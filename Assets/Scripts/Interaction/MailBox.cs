using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * manage the sequence of events after mailbox is selected
 * child: text, videoclip, pickup item: letter
 * if required item is not selected in the inventory, clicking on the mailbox shows text
 * else play the video and enable the letter for pickup
 */
public class MailBox : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject invitationLetter;
    public static bool StringAqiured; 

    void Start()
    {
        StringAqiured = false;
        text.SetActive(true);
        video.SetActive(false);
        invitationLetter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StringAqiured) // the player clicked the right tool and clicked the mailbox
        {
            text.SetActive(false);
            if (video != null)
                video.SetActive(true);
            // after 2 seconds (the video is played and destroyed)
            else if (invitationLetter != null)
                invitationLetter.SetActive(true);

        }
    }
}
