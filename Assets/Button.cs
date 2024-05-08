using UnityEngine;

public class Button : MonoBehaviour
{
    public Material On;
    public Material Off;
    public Door door;
    private int _insideCounter;
    private void OnTriggerEnter(Collider other)
    {
        _insideCounter++;
        if (_insideCounter == 1)
        {
            door.Open();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _insideCounter--;
        Debug.Assert(_insideCounter >= 0);
        if (_insideCounter == 0)
        {
            door.Close();
        }
    }
}
