using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody rb;

    public float moveSpeed;
    public float normalSpeed = 6f;
    public float jumpForce = 12f;
    public float sprintSpeed = 60f;

    public LayerMask layerMask;
    public bool Grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveSpeed = 6f;
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        Vector3 movePosition = transform.right * x + transform.forward * y;
        Vector3 newMovePosition = new Vector3(movePosition.x, rb.velocity.y, movePosition.z);

        rb.velocity = newMovePosition;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        Grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, layerMask);

        //sprinting



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }



        //if (!(Input.GetKeyDown(KeyCode.LeftShift)))
        //{
        //    moveSpeed = normalSpeed;
        //}




    }
}
