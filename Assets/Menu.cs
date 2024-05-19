using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuOn;
    public GameObject MenuOff;

    public void Click()
    {
        MenuOn.SetActive(true);
        MenuOff.SetActive(false);
    }
}
