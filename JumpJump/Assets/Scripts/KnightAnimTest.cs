using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimTest : MonoBehaviour {

    bool isSelected = true;

    Rigidbody2D rb2D;
    Animator anim;
    Vector2 jump;
    public bool isGrounded = true;
    Vector3 jumpVelocity;
    Vector3 startingPos;

    float skinWidth = 0.015f;

    public float jumpForce = 5;
    public int rayCount = 4;
    float raySpacing; 

    public bool isTheGameStarted = false;


	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jump = Vector2.up;
        if(!isTheGameStarted)
        {
            rb2D.gravityScale = 0;
        }
	}
	

	void Update () {

        if(isSelected)
        {
            anim.SetBool("IsSelected", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            rb2D.AddForce(jump * jumpForce, ForceMode2D.Impulse);

        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("IsAttacking");
        }

        anim.SetFloat("JumpVelocity", transform.position.y);

	}


}
