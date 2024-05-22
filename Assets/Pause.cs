using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool pause;

    public GameObject Menu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

            if (pause)
            {
                Time.timeScale = 0;
                Menu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Menu.SetActive(pause);
            }
        }
    }

    public void UnPause()
    {
        pause = false;
        Time.timeScale = 1;
        Menu.SetActive(pause);
    }
}
