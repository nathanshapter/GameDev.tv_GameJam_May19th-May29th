using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    Rigidbody2D rb;
    [SerializeField] float speedActuel = 10;
    bool isFacingRight;
    [SerializeField] float coyoteTime;
    float coyoteTimeCounter;
    [SerializeField] GameObject groundCheck;
    public LayerMask groundLayer;
    [SerializeField] float jumpingPower = 50;

    Animator animator;
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        if(context.performed) { transform.SetParent(null); }
    }

    public void Jump(InputAction.CallbackContext context)
    {

        
        if (context.performed && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            //   animator.SetBool("Grounded", false);

            //  animator.SetBool("walk", false);
            //  animator.SetBool("isRunning", false);
              animator.SetTrigger("Jump");






        }
        if (context.canceled && rb.velocity.y > 0f )
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;

        }
    }


    public bool IsGrounded()
    {
              

       

        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.5f, groundLayer);

    }
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        FlipPlayer();

        

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            
        }
    }


    private void FlipPlayer()
    {
         rb.velocity = new Vector2(horizontal * speedActuel, rb.velocity.y); 


        if (isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (!isFacingRight && horizontal < 0f)
        {
            Flip();

        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x /= -1f;
        transform.localScale = localScale;

    }


}
