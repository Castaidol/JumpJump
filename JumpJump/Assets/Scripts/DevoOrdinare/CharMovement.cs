using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMovement : MonoBehaviour
{
    public const float skinWidth = 0.02f;
    public int verticalRayCount = 4;
    public Text healtText;
    public LayerMask collisionMask;
    float jumpForce = 10;
    public float xForce;
    public int healt = 10;

    private float positionTileX;
    private float speed = 5f;

    private Rigidbody2D rb2D;
    private BoxCollider2D col2D;

    private Vector2 raycastOrigin;
    private float verticalRaySpacing;
    private CollisionInfo collisionInfo;


	private void Start()
	{
        rb2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<BoxCollider2D>();

        CalculateRaycastSpacing();
        collisionInfo.Reset();

	}

	private void Update()
	{
        healtText.text = healt.ToString();

        VerticalCollision();

        if(Input.GetKeyDown(KeyCode.UpArrow) && collisionInfo.below)
        {
            Vector2 force = new Vector2(xForce, jumpForce);
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
                //Debug.Log(positionTileX);
            }

            if(hit)
            {
                MoveToPosition();

                if(transform.position.x == positionTileX) collisionInfo.below = true;
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

    public struct CollisionInfo
    {
        public bool below;

        public void Reset()
        {
            below = false;
        }
    }

    void MoveToPosition()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(positionTileX, transform.position.y, transform.position.z), step);
    }

}
