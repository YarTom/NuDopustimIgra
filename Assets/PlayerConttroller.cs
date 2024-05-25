using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerConttroller : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource _au;
    public List<AudioClip> sounds;
	public float Speed;
    public float Gravity;
    public float JumpSpeed;
    public float GravityVelocity;
    public CapsuleCollider BoxCollider;

    public GameObject WinMenu;
    public GameObject Pause;

    // My
    private float _fallVelocity = 0;
    //private bool isGrounded;

    public bool IsMirrorClone;

    private Animator _an;

    private void Awake()
    {
        _au = GetComponent<AudioSource>();
        BoxCollider = GetComponent<CapsuleCollider>();
        _an = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        if (IsMirrorClone)
        {
            Speed *= -1;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1.0f;
        }
    }
    void FixedUpdate()
    {
        bool raycastHit = Physics.Raycast(BoxCollider.bounds.center, Vector3.down, BoxCollider.bounds.extents.y);
        Debug.DrawRay(BoxCollider.bounds.center, Vector3.down * BoxCollider.bounds.extents.y, Color.red);
        if (raycastHit)
        {
            _fallVelocity = 0;
            //isGrounded = true;
        }
        else
        {
            _fallVelocity += Gravity * Time.fixedDeltaTime;
            //isGrounded = false;
        }
        var horiontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horiontal * Speed * Time.fixedDeltaTime, _fallVelocity * Time.fixedDeltaTime, vertical * Math.Abs(Speed) * Time.fixedDeltaTime);
        if (horiontal != 0 || vertical != 0)
        {
            if (!IsMirrorClone)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(Math.Sign(Speed) * horiontal * Time.fixedDeltaTime, 0, Math.Sign(Speed) * vertical * Time.fixedDeltaTime));
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(Math.Sign(Speed) * horiontal * Time.fixedDeltaTime, 0, Math.Sign(Speed) * -vertical * Time.fixedDeltaTime));
            }
            
            _an.SetBool("IsRun", true);
        }
        else
        {
            _an.SetBool("IsRun", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Exit>(out Exit component) && !IsMirrorClone)
        {
            WinMenu.SetActive(true);
            Destroy(Pause);
            Time.timeScale = 0;
            _au.PlayOneShot(sounds[0]);
        }
    }
}
