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



    private void Start()
    {
        //sets text in the beggining of the game to "hello"
        

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        if (horizontal != 0)
        {
            anim.SetTrigger("Run");
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
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Walk()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        
    }
}
