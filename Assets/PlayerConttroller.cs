using UnityEngine;
using System;

public class PlayerConttroller : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController ch;

	public float Speed;
    public float Gravity;
    public float JumpSpeed;
    public float GravityVelocity;

    // My
    private float _fallVelocity = 0;
    public bool isGrounded;

    public bool IsMirrorClone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        if(IsMirrorClone)
        {
            Speed *= -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    void FixedUpdate()
    {
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        if (isGrounded)
        {
            _fallVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {

            _fallVelocity += JumpSpeed;
        }

        var horiontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horiontal * Speed * Time.fixedDeltaTime, _fallVelocity * Time.fixedDeltaTime, vertical * Speed * Time.fixedDeltaTime);
        if (horiontal != 0 || vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(Math.Sign(Speed) * horiontal * Time.fixedDeltaTime, 0, Math.Sign(Speed) * vertical * Time.fixedDeltaTime));
        }
    }
    
    
}
