using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    public float speed = 1;
    public float jumpForce = 5;


    private Rigidbody2D body;
    private Animator animator;
    private bool canJump; 

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    void Mouvement()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            animator.SetInteger("X", 1);
            body.velocity = new Vector2(speed, body.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("X", 1);
            body.velocity = new Vector2(-speed, body.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            animator.SetInteger("X", 0);
            body.velocity = new Vector2(0, body.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump && body.velocity.y >= 0)
        {
            animator.SetTrigger("Jump");
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            canJump = false;
        }

        Animate();
    }

    void Animate()
    {
        if(body.velocity.x == 0)
        {
            animator.SetInteger("X", 0);
        }

        if (body.velocity.y < -1)
        {
            animator.SetInteger("Y", -1);
        }
        else
        {
            animator.SetInteger("Y", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Ground" )
        {
            canJump = true;
        }
    }

}
