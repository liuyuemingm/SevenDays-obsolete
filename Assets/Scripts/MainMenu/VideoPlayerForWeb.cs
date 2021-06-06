using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerForWeb : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public void PlayVideo() 
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Party 1");
        videoPlayer.Play();
    }
}
    