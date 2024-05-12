using UnityEngine;

public class Button : MonoBehaviour
{
    public Door door;
    private int _insideCounter;

    public GameObject ButonOn;
    public GameObject ButonOff;
    private void OnTriggerEnter(Collider other)
    {
        ButonOn.SetActive(true);
        ButonOff.SetActive(false);
        _insideCounter++;
        if (_insideCounter == 1)
        {
            door.Open();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ButonOn.SetActive(false);
        ButonOff.SetActive(true);
        _insideCounter--;
        Debug.Assert(_insideCounter >= 0);
        if (_insideCounter == 0)
        {
            door.Close();
        }
    }
}
