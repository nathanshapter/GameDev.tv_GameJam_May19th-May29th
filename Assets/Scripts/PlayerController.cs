using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    Rigidbody2D rb;
    [SerializeField] float speedActuel = 10;
   public bool isFacingRight;
    [SerializeField] float coyoteTime;
    float coyoteTimeCounter;
    [SerializeField] GameObject groundCheck;
    public LayerMask groundLayer, boxLayer;
    [SerializeField] float jumpingPower = 50;

    Animator animator;

    [SerializeField] GameObject throwableLight;
    [SerializeField] Transform lightSpawn;
    [SerializeField] float timeBetweenBullets = 0.25f;

    bool lightJustThrown = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        FlipPlayer();
        if (IsGrounded() || OnBox())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;

        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
      
        animator.SetBool("isRunning", true);
        if (context.canceled)
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void ThrowLight(InputAction.CallbackContext context)
    {
        if (!lightJustThrown)
        {
            StartCoroutine(ResetLight());

        }      
    }

    IEnumerator ResetLight() 
    {
        
        lightJustThrown = true;
        yield return new WaitForSeconds(0.25f);
        Instantiate(throwableLight, lightSpawn.position, transform.rotation);

        yield return new WaitForSeconds(timeBetweenBullets);
        lightJustThrown = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {        
        transform.SetParent(null);  


        if (context.performed && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            
              animator.SetTrigger("Jump");
        }
        if (context.canceled && rb.velocity.y > 0f )        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }
    public bool IsGrounded()
    {            
        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.5f, groundLayer);

    }
    
    public bool OnBox()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.5f, boxLayer);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.transform.CompareTag("Box") || collision.transform.CompareTag("Ground"))
        {
            transform.SetParent(collision.transform);
        }
    }
   

}
