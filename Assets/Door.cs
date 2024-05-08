using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen;
    private void OnCollisionEnter(Collision collision)
    {
        if (IsOpen)
        {
            if (collision.gameObject.TryGetComponent<PlayerConttroller>(out var player))
            {
                Debug.Log("Есть контакт");
            }
        }
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
    }
}
