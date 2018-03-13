using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour {

    public Vector2 jump;

    public Button moveButton;

    Controller2D controller;

    public float JumpHeight = 4f;
    public float timeToJumpApex = .4f;

    float gravity;
    float jumpVelocity;
    float velocityXSmoothing;

    Vector2 input;
    Vector3 velocity;

	private void Awake()
	{
        controller = GetComponent<Controller2D>();
        //Button bnt = moveButton.GetComponent<Button>();
        //bnt.onClick.AddListener(Jump);
	}

    private void Update()
    {
        CalculateGravity();



        if(controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
            velocity.x = jump.x;
        }

        float targetVelocity = input.x;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocity, ref velocityXSmoothing, .1f);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
	void CalculateGravity()
    {

        gravity = -(2 * JumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

    }

    void Jump(){
        if (controller.collisions.below)
        {
            input = jump;
            Debug.Log("jump");
        }
    }

}
