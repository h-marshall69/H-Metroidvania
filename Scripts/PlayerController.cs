using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float speed, jumHeigth;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
        if(isGrounded) {
            anim.SetBool("Jump", false);
        } else {
            anim.SetBool("Jump", true);
        }
        FlipCharapter();
        Attack();
    }
    public void Attack() {
       //anim.SetBool("Attack", true);
        if(Input.GetButton("Fire1")) {
            anim.SetBool("Attack", true);
        } else {
            anim.SetBool("Attack", false);
        }
    }

    public void FixedUpdate() {
        Movement();
        Jump();
    }

    public void Movement() {
        velX = Input.GetAxis("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);

        if(rb.velocity.x != 0) {
            anim.SetBool("Run", true);
        } else {
            anim.SetBool("Run", false);
        }
    }

    public void Jump() {
        if(Input.GetButton("Jump") && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumHeigth);
        }
    }

    public void FlipCharapter() {
        if(rb.velocity.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        } else if(rb.velocity.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    
}
