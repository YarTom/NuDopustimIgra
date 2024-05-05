using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConttroller : MonoBehaviour
{
	private Rigidbody rb;
	public float Speed;
    public float Gravity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var horiontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horiontal * Speed * Time.fixedDeltaTime, Gravity, vertical * Speed * Time.fixedDeltaTime);
        
    }

   
}
