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

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.anim = this.GetComponent<Animator>();
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
        Quaternion deltaRotation = Quaternion.Euler(this.eulerAngleVelocity * Time.fixedDeltaTime);
        this.eulerAngleVelocity = new Vector3(0, Input.GetAxis("Mouse X") * this.speedRotation, 0);
        this.rb.MoveRotation(this.rb.rotation * deltaRotation);
    }

    void Movement()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") * this.speed * Time.fixedDeltaTime, 0,
                                      Input.GetAxis("Vertical") * this.speed * Time.fixedDeltaTime);
        this.rb.MovePosition(this.rb.position + transform.TransformDirection(m_Input));

        // Set Animation: Walking
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            this.anim.SetBool("isWalking", true);

        } else
        {
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

    void PlayerActions()
    {
        this.Movement();
        this.Rotation();
        this.Jump();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            this.isGrounded = true;
    }
}
