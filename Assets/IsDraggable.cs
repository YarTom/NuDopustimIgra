using UnityEngine;

public class IsDraggable : MonoBehaviour
{
    public GameObject Object;
    private bool _isGrab = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerConttroller>();
        if (player != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isGrab = !_isGrab;
                if (_isGrab)
                {
                    Object.transform.SetParent(player.transform);
                    rb.freezeRotation = true;
                }
                else
                {
                    Object.transform.SetParent(null);
                    rb.freezeRotation = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerConttroller>();
        if (player != null)
        {
            _isGrab = false ;
        }
    }
}
