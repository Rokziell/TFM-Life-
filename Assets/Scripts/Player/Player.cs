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
    private  bool isGrabbing;
    private float horizontal;
    private float vertical;
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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        
        if(!isGrabbing)
        {
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
        else
        {
            vertical = Input.GetAxisRaw("Vertical");
            Vector3 newDirection = new Vector3(0f, 0f, vertical);
            objectPicked.GetComponent<InteractableObjectMovement>().StartMoving(transform, newDirection);
            moveDirection = new Vector3(vertical, 0f, 0f);
        }
    }

    void Jump()
    {
        if(isGrounded)
        {
            moveDirection.y = 0;
        }
        if (isGrounded && Input.GetButton("Jump") && !isGrabbing)
        {
            this.moveDirection.y = this.jumpSpeed;
        }
        this.moveDirection.y -= this.gravity * Time.fixedDeltaTime;
    }

    private GameObject objectPicked;
    public void MoveWithObject(GameObject objectToMove)
    {
        if(isGrounded)
        {
            if(objectToMove != null)
            {
                objectPicked = objectToMove;
                transform.SetParent(objectPicked.transform);
                isGrabbing = true; 
            }else
            {
                transform.SetParent(null);
                objectPicked = objectToMove;
                isGrabbing = false;
            }
        }
    }

    public void Move() 
    {
        if(!isGrabbing)
        {
            this.controller.Move(this.moveDirection * Time.fixedDeltaTime);            
        }
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
