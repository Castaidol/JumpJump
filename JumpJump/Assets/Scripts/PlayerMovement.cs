using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float jumpForce = 5f;

    private Transform playerTransform;
    private Rigidbody2D rb2d;

	private void Awake()
	{
        playerTransform = transform;
        rb2d = GetComponent<Rigidbody2D>();
	}

	public void MovePlayer(){

        rb2d.AddForce(new Vector2(1, jumpForce), ForceMode2D.Impulse);


    }

}
