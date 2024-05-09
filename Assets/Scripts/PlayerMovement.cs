using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 60f;
    public float runSpeed = 90f;
    /* Codigo nuevo -----------------------------------------------------------------------------*/
    public float dashSpeed = 300F;
    /*-------------------------------------------------------------------------------------------*/
    public float jumpPower = 90f;
    public float gravity = 200f;
    public float lookSpeed = 2f;
    public float lookXLimit = 90f;
    public float defaultHeight = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    /* Codigo nuevo -----------------------------------------------------------------------------*/
    private bool lockedRun;

    public bool isJumping = false;
    public bool holdJump = false;
    public float pressedJump = 0f;

    private float dashCooldown = 0f;
    private float dashDuration = 0f;
    private bool holdDash = false;
    private bool isDashing = false;
    private const float DASH_DURATION = 0.2f;
    private const float DASH_COOLDOWN = 2f;
    private const float MAX_JUMP_HEIGHT = 0.5f;
    /*-------------------------------------------------------------------------------------------*/

    private bool canMove = true;

    public void blockMovement()
    {
        canMove = false;
        moveDirection = Vector3.zero;
    }
    public void enableMovement()
    {
        canMove = true;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        dash();

        float movementDirectionY = computeMovement();
        bool grounded = characterController.isGrounded;

        jump(movementDirectionY, grounded);

        fall(grounded);

        updateMovement();

        rotateCamera();


    }
    /* Codigo nuevo -----------------------------------------------------------------------------*/
    void dash()
    {

        Vector3 forward = playerCamera.transform.forward;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (dashCooldown <= 0 && holdDash == false)
            {
                isDashing = true;
                dashDuration = 0;
                dashCooldown = DASH_COOLDOWN;
                holdDash = true;
                canMove = false;

            }
        }
        else
        {
            holdDash = false;
        }
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }

        if (isDashing)
        {
            if (dashDuration < DASH_DURATION)
            {
                moveDirection = (forward * dashSpeed);
                dashDuration += Time.deltaTime;
                dashCooldown -= Time.deltaTime;
            }
            else
            {
                moveDirection = (forward * walkSpeed);
                isDashing = false;
                canMove = true;
            }
        }
    }
    /*-------------------------------------------------------------------------------------------*/
    float computeMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        /* Codigo nuevo -----------------------------------------------------------------------------*/
        if (isRunning) { lockedRun = true; }
        /*-------------------------------------------------------------------------------------------*/

        /* Lineas modificadas -----------------------------------------------------------------------*/
        float curSpeedX = canMove ? (lockedRun ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (lockedRun ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        /*-------------------------------------------------------------------------------------------*/

        float movementDirectionY = moveDirection.y;
        //Debug.Log(moveDirection);
        if (canMove)
        {
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        }
        //Debug.Log(moveDirection);
        /* Codigo nuevo -----------------------------------------------------------------------------*/
        if (moveDirection.x == 0 && moveDirection.z == 0) { lockedRun = false; }
        /*-------------------------------------------------------------------------------------------*/
        return movementDirectionY;
    }
    void jump(float movementDirectionY, bool grounded)
    {

        if (canMove)
        {
            isJumping = Input.GetButton("Jump");
            if (isJumping && grounded && pressedJump == 0)
            {
                moveDirection.y = jumpPower;
                holdJump = true;
            }
            else if (!isJumping || (pressedJump > MAX_JUMP_HEIGHT))
            {
                moveDirection.y = movementDirectionY;
                holdJump = false;
            }
            else if (isJumping && !grounded && holdJump)
            {
                moveDirection.y = jumpPower;
                pressedJump += Time.deltaTime;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
            if (!isJumping)
            {
                pressedJump = 0;
            }
        }
        else
        {
            pressedJump += 5;
            moveDirection.y = movementDirectionY;
        }
    }
    void fall(bool grounded)
    {
        if (!grounded)
        {
            moveDirection.y -= (gravity * Time.deltaTime);
        }
    }

    void updateMovement()
    {
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void rotateCamera()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}