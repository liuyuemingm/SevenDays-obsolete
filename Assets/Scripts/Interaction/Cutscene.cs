using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    private DisplayImage currentDisplay;
    private VideoPlayer videoPlayer;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        GetComponent<RawImage>().enabled = false;
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.enabled = true;
    }

    private void Update()
    {
        currentDisplay.CurrentState = DisplayImage.State.cutscene;
        if (!GetComponent<RawImage>().enabled && videoPlayer.frame > 0)
            GetComponent<RawImage>().enabled = true;
        if (videoPlayer.frame == ((long)videoPlayer.frameCount-1)) 
        { 
            currentDisplay.CurrentState = DisplayImage.State.changeView;
            Destroy(gameObject);
        }
    }

    
}
