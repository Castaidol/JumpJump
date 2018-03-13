using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour {

    public Vector2 jump;

    Controller2D controller;

    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;

    Vector3 velocity;

	private void Awake()
	{
        controller = GetComponent<Controller2D>();
	}

    private void Update()
    {
        CalculateGravity();

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        velocity.x = input.x;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
	void CalculateGravity()
    {

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

    }

}
