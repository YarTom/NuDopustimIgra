using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lore : MonoBehaviour
{
    public List<GameObject> Images;
    public GameObject BlackScreen;
    public GameObject Text;
    public List<string> text;
    private AudioSource _au;
    public List<AudioClip> sound;
    private int numberOfSymbol;
    private int numberOfStroke;
    private bool IsEnd = false;


    private void Start()
    {
        Cursor.visible = false;
        _au = GetComponent<AudioSource>();
        Invoke("End", 28.8f);
        Images[1].SetActive(false);
        Images[2].SetActive(false);
        Text.GetComponent<Text>().text = null;
        numberOfStroke = 0;
        StartCoroutine(Text1());
        BlackScreenOut();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space)) && !IsEnd)
        {
            End();
        }

        if (numberOfStroke == 0 && numberOfSymbol == 51)
        {
            Invoke("BlackScreenIn", 1f);
            Invoke("BlackScreenOut", 2.1f);
            Invoke("ImageChange1", 2f);
        }
    }

    IEnumerator Text1()
    {
        yield return null;

        while (numberOfStroke < text.Count)
        {
            Text.GetComponent<Text>().text = null;
            numberOfSymbol = 0;
            while (numberOfSymbol < text[numberOfStroke].Length)
            {
                Text.GetComponent<Text>().text += text[numberOfStroke][numberOfSymbol];
                numberOfSymbol++;
                _au.PlayOneShot(sound[1]);
                yield return new WaitForSeconds(0.07f);
            }

            numberOfStroke++;

            yield return new WaitForSeconds(2);
        }
    }

    private void BlackScreenOut()
    {
        BlackScreen.GetComponent<Image>().color = new Color(BlackScreen.GetComponent<Image>().color.r, BlackScreen.GetComponent<Image>().color.g, BlackScreen.GetComponent<Image>().color.b, BlackScreen.GetComponent<Image>().color.a - 0.01f);
        if (BlackScreen.GetComponent<Image>().color.a > 0)
        {
            Invoke("BlackScreenOut", 0.01f);
        }
        
    }
    
    private void BlackScreenIn()
    {
        BlackScreen.GetComponent<Image>().color = new Color(BlackScreen.GetComponent<Image>().color.r, BlackScreen.GetComponent<Image>().color.g, BlackScreen.GetComponent<Image>().color.b, BlackScreen.GetComponent<Image>().color.a + 0.01f);
        if (BlackScreen.GetComponent<Image>().color.a < 1)
        {
            Invoke("BlackScreenIn", 0.01f);
        }
        
    }

    private void ImageChange1()
    {
        Images[0].SetActive(false);
        Images[1].SetActive(true);
    }

    private void End()
    {
        IsEnd = true;
        Images[2].SetActive(true);
        _au.Stop();
        _au.PlayOneShot(sound[0]);
        Invoke("ToMenu", 3f);
    }

    private void ToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
