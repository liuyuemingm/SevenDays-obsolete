using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    public GameObject[] videos;
    private short videoIndex;
    private bool rawImageEnabled;

    private void Awake()
    {
        videoIndex = -1;
        foreach (GameObject a in videos)
        {
            a.GetComponent<RawImage>().enabled = false;
            a.SetActive(false);
            a.transform.Find("Button").gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (videoIndex != -1 && videos[videoIndex].GetComponent<VideoPlayer>().frame >= 0 && !rawImageEnabled)
        {
            videos[videoIndex].GetComponent<RawImage>().enabled = true;
            rawImageEnabled = true;
            videos[videoIndex].transform.Find("Button").gameObject.SetActive(false);
            if (videoIndex >= 1)
                videos[videoIndex - 1].transform.Find("Button").gameObject.SetActive(false);
        }

        if (videoIndex != -1 && videos[videoIndex].GetComponent<VideoPlayer>().frame ==
            (long)videos[videoIndex].GetComponent<VideoPlayer>().frameCount-1)
        {
            videos[videoIndex].transform.Find("Button").gameObject.SetActive(true);
        }

    }

    public void PlayNextVideo()
    {
        
        rawImageEnabled = false;
        videoIndex++;
        videos[videoIndex].SetActive(true);
    }

}
