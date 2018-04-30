using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[DisallowMultipleComponent]
public class SoundController : SaveableData {

    [HideInInspector]
    public static SoundController instance = null;

    public AudioSource backgroundSource;
    public AudioSource[] sounds;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        backgroundSource.volume = GetMusicVolume();

        foreach (AudioSource sound in sounds)
        {
            sound.volume = GetSoundVolume();
        }
    }

    public void CreateNewSound(AudioClip sound, bool loopSound = false)
    {
        GameObject obj = new GameObject();
        obj.transform.parent = transform;
        obj.AddComponent<AudioSource>();
        obj.GetComponent<AudioSource>().clip = sound;
        obj.GetComponent<AudioSource>().loop = loopSound;
        obj.GetComponent<AudioSource>().volume *= GetSoundVolume();
        obj.GetComponent<AudioSource>().Play();

        if (!loopSound)
            Destroy(obj, sound.length);
    }

    public float ReturnSoundVolume()
    {
        return GetSoundVolume();
    }

}
