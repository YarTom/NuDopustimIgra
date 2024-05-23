using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private AudioSource _au;
    public List<AudioClip> sounds;

    public int ButtonCount = 1;
    private int ButtonOnCount;

    public bool IsOpen;
    private Animator _an;

    private void Awake()
    {
        _an = GetComponent<Animator>();
        _au = GetComponent<AudioSource>();
    }

    public void Open()
    {
        ButtonOnCount++;
        if (ButtonOnCount >= ButtonCount)
        {
            IsOpen = true;
            _an.SetBool("IsOpen", true);
            _au.PlayOneShot(sounds[0]);
        }
        
    }

    public void Close()
    {
        ButtonOnCount--;
        if (ButtonOnCount < ButtonCount && IsOpen)
        {
            IsOpen = false;
            _an.SetBool("IsOpen", false);
            _au.PlayOneShot(sounds[1]);
        }
    }
}
