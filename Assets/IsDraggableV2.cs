using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDraggableV2 : MonoBehaviour
{
    private GameObject followObj;
    private bool _canDrag;
    private Rigidbody rb;

    public GameObject On;
    public GameObject Off;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerConttroller>(out PlayerConttroller component))
        {
            _canDrag = true;
            followObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerConttroller>(out PlayerConttroller component))
        {
            _canDrag = false;
            followObj = null;
        }
    }

    private void Update()
    {
        if (_canDrag && Input.GetKey(KeyCode.Space) && followObj != null)
        {
            rb.AddForce(new Vector3(transform.position.x - followObj.transform.position.x, transform.position.y - followObj.transform.position.y, transform.position.z - followObj.transform.position.z).normalized * -30);
        }

        if (_canDrag && Input.GetKeyDown(KeyCode.Space))
        {
            On.SetActive(true);
            Off.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Space) || !_canDrag)
        {
            On.SetActive(false);
            Off.SetActive(true);
        }
    }

}
