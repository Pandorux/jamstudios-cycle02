using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[DisallowMultipleComponent]
public class SoundController : MonoBehaviour {

    [HideInInspector]
    public static SoundController instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void CreateNewSound(AudioClip sound, bool loopSound = false)
    {
        GameObject obj = new GameObject();
        obj.transform.parent = transform;
        obj.AddComponent<AudioSource>();
        obj.GetComponent<AudioSource>().clip = sound;
        obj.GetComponent<AudioSource>().loop = loopSound;
        obj.GetComponent<AudioSource>().Play();

        if (!loopSound)
            Destroy(obj, sound.length);
    }

}
