using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private AudioSource _au;
    public GameObject Text;
    public List<string> text;
    private int numberOfSymbol;
    public List<AudioClip> sound;

    void Start()
    {
        _au = GetComponent<AudioSource>();
        StartCoroutine(Text1());
    }

    IEnumerator Text1()
    {
            Text.GetComponent<Text>().text = null;
            numberOfSymbol = 0;
            while (numberOfSymbol < text[SceneManager.GetActiveScene().buildIndex].Length)
            {
                Text.GetComponent<Text>().text += text[SceneManager.GetActiveScene().buildIndex][numberOfSymbol];
                numberOfSymbol++;
                _au.PlayOneShot(sound[0]);
                yield return new WaitForSeconds(0.07f);
            }

        yield return new WaitForSeconds(4);
        
        Text.SetActive(false);
    }
}
