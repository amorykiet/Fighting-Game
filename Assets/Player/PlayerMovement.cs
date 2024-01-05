using System;
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
    public Animator animator;

    public float runSpeed = 7f;
    public float runAttackSpeed = 3f;
    public float forceJump = 10f;
    public float jumpTime = 0f;
    public float reactionForce;
    public bool canRun = true;

    float jumpTimeCounter = 0f;
    float horizontalMove = 0f;
    bool isGrounded = false;
    bool isJumping = false;
    bool canFlip = true;
    float speed;

    // Update is called once per frame
    private void Start()
    {
        speed = runSpeed;
        enableRun();

    }
    void Update()
    {
        if (!canRun)
        {
            return;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("run speed", Math.Abs(horizontalMove));
        animator.SetFloat("jump speed", Math.Abs(rb.velocity.y));
        animator.SetFloat("jump velocity", rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, whatIsGround);

        if (canFlip)
        {
            if (horizontalMove > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (horizontalMove < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
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
            if (rb.velocity.y > 0)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        if (canRun)
        {
            rb.velocity = new Vector2 (horizontalMove, rb.velocity.y);
        }
    }

    public void enableMoveAttack()
    {
        canFlip = false;
        speed = runAttackSpeed;
    }
    public void disableMoveAttack()
    {
        canFlip = true;
        speed = runSpeed;
    }
    
    public void jumpWithAttack()
    {
        rb.velocity = new Vector2(rb.velocity.x, reactionForce);
    }

    public void disableRun()
    {
        canRun = false;
        rb.velocity = Vector2.zero;
    }

    public void enableRun()
    {
        canRun = true;
    }
}
