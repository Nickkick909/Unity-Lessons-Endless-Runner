using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded = false;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPosition;
    public float distanceTravelled;

    [SerializeField] UIController uiController;

    private void Start()
    {
        lastYPosition = transform.position.y;
    }
    // Update is better for input
    void Update()
    {
        CheckForInput();
        CheckPlayerFalling();

        distanceTravelled += Time.deltaTime;
    }

    // Fixed Update is better for physics
    void FixedUpdate()
    {
        CheckIsGrounded();
        TriggerJump();
    }

    void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
            anim.SetTrigger("Jump");
        }
    }

    void CheckIsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
                Debug.Log(hit.transform.name);
                anim.SetBool("IsGrounded", true);
            }
            else
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", false);
            }
        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
    }

    void CheckPlayerFalling ()
    {
        if (transform.position.y < lastYPosition)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }
        lastYPosition = transform.position.y;
    }

    void TriggerJump()
    {
        if (jump)
        {
            jump = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            uiController.ShowGameOver();
        }
    }
}