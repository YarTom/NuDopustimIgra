using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.LookAt(player.position);
    }
}
