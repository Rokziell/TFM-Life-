using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity;
    [SerializeField] Transform cam;

    [SerializeField] private float jumpSpeed = 14.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        this.controller = GetComponent<CharacterController>();    
    }

    void Update()
    {
        this.Walk();
        this.Jump();
    }

    void Walk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        direction = cam.rotation * direction;
        Quaternion targetAngleQuat = Quaternion.LookRotation(direction);
        Quaternion finalRot = Quaternion.RotateTowards(transform.rotation, targetAngleQuat, turnSmoothVelocity); 
        this.transform.rotation = finalRot;

        controller.Move(transform.forward * direction.magnitude * Time.deltaTime * speed);
    }

    void Jump()
    {
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            this.moveDirection.y = this.jumpSpeed;
        }
        this.moveDirection.y -= this.gravity * Time.deltaTime;
        this.controller.Move(this.moveDirection * Time.deltaTime);
    }
}
