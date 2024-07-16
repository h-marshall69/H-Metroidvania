using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumHeigth;
    float velX, velY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipCharapter();
    }

    public void FixedUpdate() {
        Movement();
        Jump();
    }

    public void Movement() {
        velX = Input.GetAxis("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);
    }

    public void Jump() {
        if(Input.GetButton("Jump")) {
            rb.velocity = new Vector2(rb.velocity.x, jumHeigth);
        }
    }

    public void FlipCharapter() {
        if(rb.velocity.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        } else {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
