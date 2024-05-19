using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private GameObject CutsceneObject;
    private bool IsCutscene;
    public List<Transform> player;
    private int i;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            i++;
            if (i > player.Count - 1)
            {
                i = 0;
            }
        }

        if (!IsCutscene)
        {
            Look(player[i].gameObject);
        }
        else
        {
            Look(CutsceneObject);
        }
    }

    public void Cutscene(GameObject lookat, float time)
    {
        IsCutscene = true;
        CutsceneObject = lookat;
        Invoke("ExitCutscene", time);
    }

    private void ExitCutscene()
    {
        IsCutscene = false;
    }

    private void Look(GameObject lookat)
    {
        transform.position = new Vector3(lookat.transform.position.x * 0.8f, transform.position.y, transform.position.z);
        transform.LookAt(lookat.transform.position);
    }
}
