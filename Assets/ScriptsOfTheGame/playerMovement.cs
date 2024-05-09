using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerMovement : MonoBehaviour
{
    
    private float horizontal;
    [SerializeField] float speed = 8f;
    [SerializeField] float jumpPower = 12;
    private bool isFacingRight = true;

    [Space]

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;

    [Space]

    [SerializeField] Animator anim;

    [Space]

    [SerializeField] private Transform ps;
    public ParticleSystem popExplosion;

    [Space]

    public GameObject enemy;
    [SerializeField] bool isGrounded;

    [SerializeField] private Transform wallCheck;

    [SerializeField] bool isWalled;


    private void Start()
    {
        //sets text in the beggining of the game to "hello"
        

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }





        if (Input.GetButtonDown("Jump") && isWalled)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        




        if (horizontal != 0)
        {
            anim.SetTrigger("Run");
        }
        else if(horizontal == 0)
        {
            anim.SetTrigger("StopRun");
        }


        if (IsStomping())
        {
            popExplosion.Play();
            ps.position = enemy.transform.position;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            Destroy(enemy);
            
            
        }

        Flip();
    }

    private void FixedUpdate()
    {

        Walk();
        RaycastHit2D hitGround = Physics2D.Raycast(groundCheck.transform.position, -Vector2.up);
        Debug.DrawRay(groundCheck.transform.position, -Vector2.up * hitGround.distance, Color.red);
        if(hitGround.collider != null)
        {
            if (hitGround.distance <= 0.2f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        if (isFacingRight)
        {
            RaycastHit2D hitWall = Physics2D.Raycast(wallCheck.transform.position, Vector2.left);
            Debug.DrawRay(wallCheck.transform.position, Vector2.left * hitWall.distance, Color.cyan);
            if (hitWall.collider != null)
            {
                if (hitWall.distance <= 0.2f)
                {
                    isWalled = true;
                    
                }
                else
                {
                    
                    isWalled = false;
                }
            }
            else
            {
                isWalled = false;
            }
        }
        else if (!isFacingRight)
        {
            RaycastHit2D hitWall = Physics2D.Raycast(wallCheck.transform.position, Vector2.right);
            Debug.DrawRay(wallCheck.transform.position, Vector2.right * hitWall.distance, Color.cyan);
            if (hitWall.collider != null)
            {
                if (hitWall.distance <= 0.2f)
                {
                    
                    isWalled = true;
                }
                else
                {
                   

                     isWalled = false;
                }

                
            }
            else
            {
                isWalled = false;
            }
        }
        
    }


    private void Flip()
    {
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }




    private bool IsStomping()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, enemyLayer);
    }
    //private bool IsGrounded()
   // {
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
   // }
    private void Walk()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        
    }
}
