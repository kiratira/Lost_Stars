using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Rigidbody2D Body;
    private Animator Anim;
    private Boolean AbleJump = true;

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    void Mouvement(){
        if(Input.GetKey(KeyCode.A)) { //Left
            Body.velocity = new Vector2(-5,Body.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D)) { //Right
            Body.velocity = new Vector2(5,Body.velocity.y);
        }
        else Body.velocity = new Vector2(0,Body.velocity.y);
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)){ //jump
            if(AbleJump) {
                Body.velocity = new Vector2(Body.velocity.x,8);
                AbleJump = false;
            }
        }
        if(Input.GetKey(KeyCode.S)) { //Something down
            Body.velocity = new Vector2(Body.velocity.x,-5);
        }

        Animate();
    }

    void Animate(){
        if(Body.velocity.y > 0.5) Anim.Play("Jump");
        else if(Body.velocity.y < -0.5 ){ 
            Anim.Play("Fall");
            AbleJump = false;
        }
        else if(Body.velocity.x > 0.5 || Body.velocity.x < -0.5) {
            Anim.Play("Run");
            if(Body.velocity.x>0.5) transform.localScale = new Vector2(2,2);
            if(Body.velocity.x<0.5) transform.localScale = new Vector2(-2,2);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") AbleJump = true;
    }
}
