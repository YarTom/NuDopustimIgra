using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private AudioSource _au;
    public List<AudioClip> sounds;
    public GameObject door;
    private int _insideCounter;

    public GameObject ButonOn;
    public GameObject ButonOff;

    private void Awake()
    {
        _au = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        
        _insideCounter++;
        if (_insideCounter == 1)
        {
            door.gameObject.GetComponent<Door>().Open();
        }
        UpdateButon();
    }
    private void OnCollisionExit(Collision other)
    {
        _insideCounter--;
        if (_insideCounter == 0)
        {
            door.gameObject.GetComponent<Door>().Close();
        }
        UpdateButon();
    }

    private void UpdateButon()
    {
        if (_insideCounter >= 1)
        {
            if (!ButonOn.activeSelf)
            {
                _au.PlayOneShot(sounds[0]);
            }
            ButonOn.SetActive(true);
            ButonOff.SetActive(false);
        }
        else
        {
            if (!ButonOff.activeSelf)
            {
                _au.PlayOneShot(sounds[1]);
            }
            ButonOn.SetActive(false);
            ButonOff.SetActive(true);
        }
    }
}
