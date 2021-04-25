using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            this.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            this.controller.Move(moveDir.normalized * this.speed * Time.deltaTime);
        }
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
