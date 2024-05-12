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
    void FixedUpdate()
    {
        var horiontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horiontal * Speed * Time.fixedDeltaTime,Time.fixedDeltaTime * Gravity, vertical * Speed * Time.fixedDeltaTime);
        if (horiontal != 0 || vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(Math.Sign(Speed) * horiontal * Time.fixedDeltaTime, 0, Math.Sign(Speed) * vertical * Time.fixedDeltaTime));
        }
    }
    
    
}
