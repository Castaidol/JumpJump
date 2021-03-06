﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMovement : MonoBehaviour
{
    public GameObject dust;

    public const float skinWidth = 0.02f;
    public int verticalRayCount = 4;
    public Text healtText;
    public LayerMask collisionMask;
    public float jumpForce = 10;
    public float jumpForwardForce = 2.045f;
    public int healt = 10;

    private float positionTileX;
    private float speed = 5f;
    private bool canJump;

    private Rigidbody2D rb2D;
    private BoxCollider2D col2D;
    private Animator anim;

    private Vector2 raycastOrigin;
    private float verticalRaySpacing;
    private CollisionInfo collisionInfo;


	private void Start()
	{
        rb2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<BoxCollider2D>();

        CalculateRaycastSpacing();
        collisionInfo.Reset();

        Button bnt = GameObject.FindGameObjectWithTag("JumpButton").GetComponent<Button>();
        bnt.onClick.AddListener(Jump);

	}
	private void FixedUpdate()
	{
        canJump = false;
	}

	private void Update()
	{
        healtText.text = healt.ToString();

        VerticalCollision();
        if(canJump && collisionInfo.below)
        {
            Vector2 force = new Vector2(jumpForwardForce, jumpForce);
            rb2D.AddForce(force, ForceMode2D.Impulse);
            collisionInfo.Reset();
        }
	}

    void VerticalCollision()
    {
        RaycastOrigin();
        Vector2 rayOrigin;
        for (int i = 0; i < verticalRayCount; i++)
        {
            rayOrigin = raycastOrigin;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, skinWidth * 2, collisionMask);
            Debug.DrawRay(rayOrigin, Vector2.up * (- skinWidth * 2 ), Color.blue);

            if (hit.collider != null)
            {
                positionTileX = hit.transform.position.x;
            }

            if(hit)
            {
                MoveToPosition();

                if(transform.position.x == positionTileX)
                {
                    if(collisionInfo.below == false)
                    {
                        if (dust != null) Instantiate(dust, new Vector3(hit.transform.position.x, hit.transform.position.y + 1, hit.transform.position.z), Quaternion.identity, hit.transform);
                    }
                    collisionInfo.below = true;

                }
            }
        }
    }

    void RaycastOrigin()
    {
        Bounds bounds = col2D.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigin = new Vector2(bounds.min.x, bounds.min.y);
    }

    public void CalculateRaycastSpacing()
    {
        Bounds bounds = col2D.bounds;
        bounds.Expand(skinWidth * -2);

        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
       
    }

    void MoveToPosition()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(positionTileX, transform.position.y, transform.position.z), step);
    }
    
    void Jump()
    {
        canJump = true;
    }

    public struct CollisionInfo
    {
        public bool below;

        public void Reset()
        {
            below = false;
        }
    }
}
