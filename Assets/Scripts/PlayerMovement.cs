using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    public float dashSpeed = 10f;
    public float dashDuration = 1f;
    public float dashCooldown = 1f;
    bool isDashing;
    void Start()
    {
       
    }

    void Update()
    {
        if (isDashing)
            return;

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * movementSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}