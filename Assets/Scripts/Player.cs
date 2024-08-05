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
    public int coinsCollected = 0;
    [SerializeField] bool canDoubleJump = false;

    [SerializeField] UIController uiController;

    [SerializeField] GameObject shieldBubble;
    [SerializeField] bool hasShield = false;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                jump = true;
                anim.SetTrigger("Jump");
            } else if (canDoubleJump)
            {
                canDoubleJump = false;
                jump = true;
                anim.SetTrigger("Jump");
            }
            
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
            if (hasShield)
            {
                Destroy(collision.gameObject);
                hasShield = false;
                shieldBubble.SetActive(false);
            } else
            {
                uiController.ShowGameOver();
            }
            
        }

        if (collision.transform.CompareTag("DeathBox"))
        {
            uiController.ShowGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Collectable"))
        {
            coinsCollected += 1;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("DoubleJump"))
        {
            canDoubleJump = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("ShieldPowerUp"))
        {
            hasShield = true;
            shieldBubble.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}