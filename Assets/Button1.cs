using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;

    private int _inTrigger;

    public GameObject ActivatingObject;

    public GameObject Camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerConttroller>(out PlayerConttroller conttroller))
        {
            _inTrigger++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerConttroller>(out PlayerConttroller conttroller))
        {
            _inTrigger--;
        }
    }

    private void Update()
    {
        if (_inTrigger > 0 && Input.GetKeyDown(KeyCode.E)) 
        {
            if (Camera != null)
            {
                Camera.GetComponent<CameraRotate>().Cutscene(ActivatingObject, 3);
            }


            On.SetActive(!On.activeSelf);
            Off.SetActive(!Off.activeSelf);

            if (On.activeSelf)
            {
                ActivatingObject.GetComponent<ActivatingObject>().Activating(1);
            }else
            {
                ActivatingObject.GetComponent<ActivatingObject>().UnActivating(1);
            }

        }
    }
}
