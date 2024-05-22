using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public int Scene;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4 && Scene == -2)
        {
            Destroy(gameObject);
        }
    }
    public void Change()
    {
        if (Scene == -1)
        {
            Application.Quit();
        }else if(Scene == -2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1.0f;
        }
        else
        {
            SceneManager.LoadScene(Scene);
            Time.timeScale = 1.0f;
        }
    }
}
