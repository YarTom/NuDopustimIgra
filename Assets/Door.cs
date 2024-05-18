using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen;
    private Animator _an;

    private void Awake()
    {
        _an = GetComponent<Animator>();
    }

    public void Open()
    {
        IsOpen = true;
        _an.SetBool("IsOpen", true);
    }

    public void Close()
    {
        IsOpen = false;
        _an.SetBool("IsOpen", false);
    }
}
