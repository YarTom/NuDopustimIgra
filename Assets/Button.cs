using UnityEngine;

public class Button : MonoBehaviour
{
    public Door door;
    private int _insideCounter;

    public GameObject ButonOn;
    public GameObject ButonOff;

    private void OnCollisionEnter(Collision other)
    {
        _insideCounter++;
        if (_insideCounter == 1)
        {
            door.Open();
        }
        UpdateButon();
    }
    private void OnCollisionExit(Collision other)
    {
        _insideCounter--;
        if (_insideCounter == 0)
        {
            door.Close();
        }
        UpdateButon();
    }
    private void UpdateButon()
    {
        if (_insideCounter >= 1)
        {
            ButonOn.SetActive(true);
            ButonOff.SetActive(false);
        }
        else
        {
            ButonOn.SetActive(false);
            ButonOff.SetActive(true);
        }
    }
}
