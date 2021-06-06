
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalCutscene : MonoBehaviour
{
    private static VideoPlayer videoPlayer;
    private bool videoActivated;
    public static bool doorClicked;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.enabled = false;
        GetComponent<RawImage>().enabled = false;
    }

    private void Update()
    {
        if (!videoActivated && doorClicked && Dialogue.DressOn && Dialogue.MaskOn && Dialogue.Invitation)
        {
            
            videoActivated = true;
            videoPlayer.enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;

            
        }
        if (videoPlayer.frame >=0)
            GetComponent<RawImage>().enabled = true;

        if (videoPlayer.frame == (long)videoPlayer.frameCount - 1)
        {
            //reset everything
            MainMenu.Reset();

            doorClicked = false;
            SceneManager.LoadScene("Start");
        }
    }
}
