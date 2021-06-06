using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static bool IntroPlayed { get;  set; }
    public GameObject VideoPlayer;
    public GameObject SkipButton;
    public GameObject CastleButton;
    public GameObject MusicSlider;
    private AudioManager audioManager;

    public void Level_1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Day1()
    {
        CastleButton.GetComponent<Button>().enabled = true;
        if (IntroPlayed)
        {
            SkipButton.SetActive(true);
            VideoPlayer.SetActive(true);
            VideoPlayer.GetComponent<VideoManager>().PlayNextVideo();
        }
        else
        {
            VideoPlayer.SetActive(true);
            VideoPlayer.GetComponent<VideoManager>().PlayNextVideo();
        }
    }
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        MusicSlider.GetComponent<Slider>().value = AudioManager.musicVolume;
        //IntroPlayed = false; // remember to change
    }

    public void MusicVol(float volumeMul)
    {
        
        audioManager.sounds[0].source.volume = volumeMul * audioManager.sounds[0].volume;
        AudioManager.musicVolume = volumeMul;
    }
    
    public static void Reset()
    {
        Dialogue.DressOn = false;
        Dialogue.MaskOn = false;
        Dialogue.MaskOn = false;
        Dresser.isOpen = false;
        
    }

}
