using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    private CharacterController controller;
    private Animator animComponent;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField] Transform cam;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothVelocity;
    [SerializeField] private float jumpSpeed = 20.0f;
    [SerializeField] private float gravity = 10.0f;

    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();    
        animComponent = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        this.Walk();
        this.Jump();
        Move();
    }

    void Walk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        
        direction = cam.rotation * direction;
        if(direction != Vector3.zero)
        {
            Quaternion targetAngleQuat = Quaternion.LookRotation(direction);
            Quaternion finalRot = Quaternion.RotateTowards(transform.rotation, targetAngleQuat, turnSmoothVelocity * Time.fixedDeltaTime); 
            this.transform.rotation = finalRot;
        }
        Vector3 playerForward = new Vector3 (transform.forward.x, 0, transform.forward.z);

        moveDirection = (Vector3.up * moveDirection.y) + (playerForward * direction.magnitude * speed);
    }

    void Jump()
    {
        if(isGrounded)
        {
            moveDirection.y = 0;
        }
        if (isGrounded && Input.GetButton("Jump"))
        {
            this.moveDirection.y = this.jumpSpeed;
        }
        this.moveDirection.y -= this.gravity * Time.fixedDeltaTime;
    }

    public void Move() 
    {
        this.controller.Move(this.moveDirection * Time.fixedDeltaTime);
        isGrounded = controller.isGrounded;
        Animations();
    }

    public void Animations()
    {
        if(moveDirection.x != 0)
        {
            animComponent.SetBool("isWalking", true);
        } else
        {
            animComponent.SetBool("isWalking", false);
        }
    }
}
