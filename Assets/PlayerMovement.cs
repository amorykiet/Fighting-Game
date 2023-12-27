using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float radiusCheck;
    public LayerMask whatIsGround;

    public float runSpeed = 7f;
    public float forceJump = 10f;
    public float jumpTime = 0f;

    float jumpTimeCounter = 0f;
    float horizontalMove = 0f;
    bool isGrounded = false;
    bool isJumping = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, whatIsGround);
        
        if (horizontalMove > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontalMove < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.C))
        {
            rb.velocity = Vector2.up * forceJump;
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }
         
        if (Input.GetKey(KeyCode.C) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * forceJump;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontalMove, rb.velocity.y);
    }
}
