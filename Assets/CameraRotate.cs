using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public List<Transform> player;
    private int i;
    void Update()
    {
        transform.LookAt(player[i].position);

        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            i++; 
            if (i > player.Count - 1)
            {
                i = 0;
            }
        }
    }
}
