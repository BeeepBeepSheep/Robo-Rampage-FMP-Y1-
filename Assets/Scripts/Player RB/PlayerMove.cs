using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //rigidbody
    private Rigidbody rb;

    //assignables
    public Transform orientation;
    public Transform playerCam;

    //speed & jump
    public float moveSpeed;
    public float normalSpeed = 6f;
    public float jumpForce = 12f;
    public float sprintSpeed = 25f;
    public float crouchSpeed = 3f;

    //ground checking
    public LayerMask whatIsGround;
    public bool Grounded;

    //wall wunning
    public LayerMask whatIsWall;
    public float wallrunForce, maxWallrunTime, maxWallSpeed;
    bool isWallRight, isWallLeft;
    bool isWallRunning;
    public float maxCameraTilt, CameraTilt;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveSpeed = 6f;
    }


    void Update()
    {

        CheckForWall();
        WallRunInput();


        //walking
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        Grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, whatIsGround);


        Vector3 movePosition = transform.right * x + transform.forward * y;
        Vector3 newMovePosition = new Vector3(movePosition.x, rb.velocity.y, movePosition.z);

        rb.velocity = newMovePosition;

        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && Grounded)
        {
            moveSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }

        //jumping

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            if (!(Input.GetKeyDown(KeyCode.LeftShift)))
            {
                //need to wait a seccond before setting move speed back
                moveSpeed = normalSpeed;
            }

        }
        //jump off walls
        WallJump();
    }

    //wallrunning
    private void WallRunInput()
    {
        if (WallRunInput.GetKey(KeyCode.D) && isWallRight) StartWallRun;
        if (WallRunInput.GetKey(KeyCode.A) && isWallLeft) StartWallRun;
    }
    private void StartWallRun()
    {
        rb.useGravity = false;
        isWallRunning = true;

        if(rb.velocity.magnitude <= maxWallSpeed)
        {
            rb.AddForce(orientation.forward * wallrunForce * maxWallrunTime.deltaTime);

            //make sure character sticks to the wall
            if (isWallRight)
                rb.AddForce(orietation.right * wallrunForce / 5 * maxWallrunTime.deltaTime);
            else
                rb.AddForce(-orietation.right * wallrunForce / 5 * maxWallrunTime.deltaTime);
        }
    }
    private void CheckForWall()
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, whatIsWall);
        //leave wall
        if (!isWallLeft && !isWallRight) StopWallRun();

    }
    private void StopWallRun()
    {
        rb.useGravity = true;
        isWallRunning = false;
    }
    private void WallJump()
    {
        if (isWallRunning)
        {
            //normal jump
            if (isWallLeft && !WallRunInput.GetKey(HeyCode.D) || isWallRight && !isWallRight && !WallRunInput.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.up * jumpForce * 1.5f);
                rb.AddForce(normalVector * jumpForce * 0.5f);
            }

            //add more force
            rb.AddForce(orientation.forward * jumpForce * 1f);
        }    
    }
}
