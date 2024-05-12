using UnityEngine;

public class PlayerConttroller : MonoBehaviour
{
    private Rigidbody rb;
	public float Speed;
    public float Gravity;
    public float JumpSpeed;
    public float GravityVelocity;

    public bool IsMirrorClone;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(IsMirrorClone)
        {
            Speed *= -1;
        }
    }
    //private void Update()
    //{
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
           // Gravity = JumpSpeed;
        //}
        
    //}
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
