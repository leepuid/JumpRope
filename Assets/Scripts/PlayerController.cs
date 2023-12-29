using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public int moveSpeed = 5;
    public float jumpForce = 10f;

    private Animator _animator;
    private Rigidbody2D rb;

    private bool isGround = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        Vector2 move = moveInput * moveSpeed;

        if (context.canceled)
        {
            _animator.SetBool("Run", false);
            rb.velocity = Vector2.zero;
            //_animator.SetBool("Idle", true);
        }
        else if (moveInput != Vector2.zero)
        {
            //_animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
            rb.velocity = new Vector2(move.x, rb.velocity.y);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && isGround)
        {
            _animator.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            _animator.SetBool("Jump", false);
            Debug.Log("true");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            Debug.Log("false");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rope"))
        {
            if(gameManager.instance != null)
            {
                gameManager.instance.DecreaseLife();
                Debug.Log("ÇÇ -1");
            }
        }
    }
}
