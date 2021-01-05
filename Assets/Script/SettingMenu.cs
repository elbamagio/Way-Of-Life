using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    

    public void SetVolume(float volume)
    {
        if (volume > -40)
        {
            audioMixer.SetFloat("volume", volume);
        }
        else
        {
            audioMixer.SetFloat("volume", -80);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

    }

}
