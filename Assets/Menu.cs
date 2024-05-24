using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuOn;
    public GameObject MenuOff;

    private void Start()
    {
        Cursor.visible = true;
    }
    public void Click()
    {
        Debug.Log("Click");
        MenuOn.SetActive(true);
        MenuOff.SetActive(false);
    }
}
