using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDraggableV2 : MonoBehaviour
{
    private bool IsDrag;
    private AudioSource _au;
    public List<AudioClip> sounds;

    private GameObject followObj;
    private bool _canDrag;
    private Rigidbody rb;

    public GameObject On;
    public GameObject Off;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _au = GetComponent<AudioSource>();
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
            if (!IsDrag)
            {
            _au.PlayOneShot(sounds[0]);
            }
            rb.AddForce(new Vector3(transform.position.x - followObj.transform.position.x, transform.position.y - followObj.transform.position.y, transform.position.z - followObj.transform.position.z).normalized * -30);
            On.SetActive(true);
            Off.SetActive(false);
            IsDrag = true;
        }
        if ((Input.GetKeyUp(KeyCode.Space) || !_canDrag) && IsDrag)
        {
            On.SetActive(false);
            Off.SetActive(true);
            IsDrag = false;
        }
        
    }

}
