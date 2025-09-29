using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float rotationSpeed = 120.0f;
    private float jumpForce = 7.0f;

    private Rigidbody rb;
    private bool isGrounded = true;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //W and S for back and forwards
        float moveInput = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveInput * moveSpeed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);


        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(0.0f, rotateInput * rotationSpeed * Time.deltaTime, 0.0f);


    }
}
