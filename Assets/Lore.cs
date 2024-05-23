using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Lore : MonoBehaviour
{
    public GameObject Text;
    public List<string> text;

    private int numberOfSymbol;
    private int numberOfStroke;


    void Start()
    {
        Text.GetComponent<Text>().text = null;
        numberOfStroke = 0;
        StartCoroutine(Wait());
        
    }
    private IEnumerator Wait()
    {
        while (numberOfStroke < text.Count)
        {
            Text.GetComponent<Text>().text = null;
            numberOfSymbol = 0;
            while (numberOfSymbol < text[numberOfStroke].Length)
            {
                Text.GetComponent<Text>().text += text[numberOfStroke][numberOfSymbol];
                numberOfSymbol++;
                yield return new WaitForSeconds(0.15f);
            }
            numberOfStroke++;

            yield return new WaitForSeconds(3);
        }
    }
}
