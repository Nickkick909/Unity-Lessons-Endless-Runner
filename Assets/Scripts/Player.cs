using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceTravelled;
    public int coinsCollected = 0;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded = false;
    [SerializeField] Animator anim;
    [SerializeField] bool canDoubleJump = false;
    [SerializeField] UIController uiController;
    [SerializeField] GameObject shieldBubble;
    [SerializeField] bool hasShield = false;
    [SerializeField] SFXManager sfxManager;

    bool jump;
    float lastYPosition;
    


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
                if (isGrounded == false)
                {
                    sfxManager.PlaySFX("land");
                }
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
            if (isGrounded)
            {
                sfxManager.PlaySFX("jump");
            } else
            {
                sfxManager.PlaySFX("doubleJump");
            }
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
                sfxManager.PlaySFX("shieldBreak");
                Destroy(collision.gameObject);
                hasShield = false;
                shieldBubble.SetActive(false);
            } else
            {
                sfxManager.PlaySFX("gameOver");
                uiController.ShowGameOver();
            }
            
        }

        if (collision.transform.CompareTag("DeathBox"))
        {
            sfxManager.PlaySFX("gameOver");
            uiController.ShowGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Collectable"))
        {
            sfxManager.PlaySFX("coin");
            coinsCollected += 1;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("DoubleJump"))
        {
            sfxManager.PlaySFX("powerUpDoubleJump");
            canDoubleJump = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("ShieldPowerUp"))
        {
            sfxManager.PlaySFX("powerUpShield");
            hasShield = true;
            shieldBubble.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}