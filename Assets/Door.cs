using UnityEngine;

public class Door : MonoBehaviour
{
    public int ButtonCount = 1;
    private int ButtonOnCount;

    public bool IsOpen;
    private Animator _an;

    private void Awake()
    {
        _an = GetComponent<Animator>();
    }

    public void Open()
    {
        ButtonOnCount++;
        if (ButtonOnCount >= ButtonCount)
        {
            IsOpen = true;
            _an.SetBool("IsOpen", true);
        }
        
    }

    public void Close()
    {
        ButtonOnCount--;
        if (ButtonOnCount < ButtonCount)
        {
            IsOpen = false;
            _an.SetBool("IsOpen", false);
        }
    }
}
