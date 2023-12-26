using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontalMove * Time.fixedDeltaTime, rb.velocity.y);
    }
}
