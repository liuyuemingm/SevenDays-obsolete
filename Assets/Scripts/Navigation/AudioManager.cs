using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public static float musicVolume;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        musicVolume = 1;
    }

    private void Start()
    {
        instance.sounds[0].source.volume = musicVolume * instance.sounds[0].volume;
        PlaySound("BeingAgain");
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }


    public void EffectsVolume(float volumeMultiplier)
    {
        for (short s = 1; s < sounds.Length; s++)
        {
            sounds[s].source.volume = volumeMultiplier * sounds[s].volume;
        }
    }
}
