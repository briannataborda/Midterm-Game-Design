using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f; 
    private Rigidbody2D rb; 
    private Vector2 moveInput; 
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed; 
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y)){
            input.y = 0;
        } else {
            input.x = 0;
        }
        
        if(context.canceled)
        {
            moveInput = Vector2.zero;
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", animator.GetFloat("InputX"));
            animator.SetFloat("LastInputY", animator.GetFloat("InputY"));
        } else {
        moveInput = input;
        animator.SetBool("isWalking", true);
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
        }
    }
}
