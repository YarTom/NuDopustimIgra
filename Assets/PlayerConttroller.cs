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
        if (horiontal != 0 || vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(horiontal * Time.fixedDeltaTime, 0, vertical * Time.fixedDeltaTime));
        }
        
    }
    
   
}
