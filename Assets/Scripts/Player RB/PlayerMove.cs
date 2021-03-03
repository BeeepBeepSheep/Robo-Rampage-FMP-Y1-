using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //rigidbody
    private Rigidbody rb;

    //assignables
    public Transform playerCam;

    //speed & jump
    public float moveSpeed;
    public float normalSpeed;
    public float jumpForce;
    public float sprintSpeed;
    public float aimingSpeed;
    public float crouchSpeed;

    //ground checking
    public LayerMask whatIsGround;
    public bool Grounded;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveSpeed = 6f;
    }


    void Update()
    {
        //walking
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        Grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, whatIsGround);


        Vector3 movePosition = transform.right * x + transform.forward * y;
        Vector3 newMovePosition = new Vector3(movePosition.x, rb.velocity.y, movePosition.z);

        rb.velocity = newMovePosition;

        //stop sprint strafe

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveSpeed = normalSpeed;
            //Debug.Log("strafe test left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveSpeed = normalSpeed;
            //Debug.Log("strafe test right");
        }




        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift)) //&& Grounded )
        {
            moveSpeed = sprintSpeed;
            Debug.Log("sprinting");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && moveSpeed != aimingSpeed)
        {
            moveSpeed = normalSpeed;
            Debug.Log("walking");
        }

        //aim speed
        if (Input.GetKeyDown(KeyCode.Mouse1) && Grounded)
        {
            moveSpeed = aimingSpeed;
            Debug.Log("aiming");
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && moveSpeed == aimingSpeed)
        {
            moveSpeed = normalSpeed;
            Debug.Log("stopped aiming");

        }

        //stoping aim sprinting
        if (Input.GetKeyDown(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = aimingSpeed;
        }


        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            if (!(Input.GetKeyDown(KeyCode.LeftShift)))
            {
                //need to wait a seccond before setting move speed back
                //Invoke("SpeedDelay", 1.0f);
                moveSpeed = normalSpeed;
            }

        }
        //void SpeedDelay()
        //{
        //    moveSpeed = normalSpeed;
        //    Debug.Log("test");
        //}

    }
}
