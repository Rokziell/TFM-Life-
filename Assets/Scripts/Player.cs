using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    [SerializeField] private float thrust;
    [SerializeField] private Vector3 eulerAngleVelocity;
    [SerializeField] private bool isGrounded;

    private AudioSource walkSound;
    private bool isWalking = false;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.anim = this.GetComponent<Animator>();
        walkSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        this.PlayerActions();
    }

    void Rotation()
    {
        this.eulerAngleVelocity = new Vector3(0, Input.GetAxis("Mouse X") * this.speedRotation, 0);
        Quaternion deltaRotation = Quaternion.Euler(this.eulerAngleVelocity * Time.fixedDeltaTime);
        this.rb.MoveRotation(this.rb.rotation * deltaRotation);
    }

    void Movement()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveDirection = m_Input * speed * Time.fixedDeltaTime;
        this.rb.MovePosition(this.rb.position + transform.TransformDirection(moveDirection));

        // Set Animation: Walking
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            isWalking = true;
            this.anim.SetBool("isWalking", true);

        } else
        {
            isWalking = false;
            this.anim.SetBool("isWalking", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && this.isGrounded)
        {
            this.rb.AddForce(this.transform.up * this.thrust, ForceMode.Impulse);
            this.isGrounded = false;
            this.anim.SetBool("isWalking", false);
        }
    }

    public void WalkSound()
    {
        if (isWalking)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else
        {
            walkSound.Stop();
        }
    }

    void PlayerActions()
    {
        this.Movement();
        this.Rotation();
        this.Jump();
        WalkSound();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            this.isGrounded = true;
    }
}
