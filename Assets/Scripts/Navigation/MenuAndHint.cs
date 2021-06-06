using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAndHint : MonoBehaviour
{
    public GameObject MusicSlider;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        MusicSlider.GetComponent<Slider>().value = AudioManager.musicVolume;
    }

    public void ToStartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void MusicVol(float volumeMul)
    {
        audioManager.sounds[0].source.volume = volumeMul * audioManager.sounds[0].volume;
        AudioManager.musicVolume = volumeMul;
    }

    public void EffectsVol(float volumeMul)
    {
        for (short s=1; s<audioManager.sounds.Length; s++)
        {
            audioManager.sounds[s].source.volume = volumeMul * audioManager.sounds[s].volume;
        }
    }


}
