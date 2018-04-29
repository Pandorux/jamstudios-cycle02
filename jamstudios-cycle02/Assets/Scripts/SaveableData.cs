using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableData : MonoBehaviour {

    #region Data Persistence

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("musicVolume", 1);
    }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="isCompleted"></param>
    protected static void SetMusicVolume(float curVolume)
    {
        PlayerPrefs.SetFloat("musicVolume", curVolume);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected static float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat("soundVolume", 1);
    }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="isCompleted"></param>
    protected static void SetSoundVolume(float curVolume)
    {
        PlayerPrefs.SetFloat("soundVolume", curVolume);
    }

    #endregion


}
