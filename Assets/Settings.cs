using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public float SndVolume;
    public float MusVolume;

    public bool IsSndScrollbar;
    public bool IsMusScrollbar;
    public bool IsSndAudioSourse;
    public bool IsMusAudioSourse;
    
    private void Start()
    {
        
        if (IsSndScrollbar)
        {
            SndVolume = PlayerPrefs.GetFloat("SndVolume");
            GetComponent<Scrollbar>().value = SndVolume;
        }
        else if (IsMusScrollbar)
        {
            MusVolume = PlayerPrefs.GetFloat("MusVolume");
            GetComponent<Scrollbar>().value = MusVolume;
        }
        else if (IsSndAudioSourse)
        {
            SndVolume = PlayerPrefs.GetFloat("SndVolume");
            GetComponent<AudioSource>().volume = SndVolume;
        }
        else if (IsMusAudioSourse)
        {
            MusVolume = PlayerPrefs.GetFloat("MusVolume");
            GetComponent<AudioSource>().volume = MusVolume;
        }
    }

    public void SndChange()
    {
        SndVolume = GetComponent<Scrollbar>().value;
        PlayerPrefs.SetFloat("SndVolume", SndVolume);
    }
    public void MusChange()
    {
        MusVolume = GetComponent<Scrollbar>().value;
        PlayerPrefs.SetFloat("MusVolume", MusVolume);
    }
}
