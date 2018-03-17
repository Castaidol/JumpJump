using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour {


    //public float smoothing = 1f;
    public float speed = 5;
    float step;
    bool startMove = false;
    Vector3 newPosition;

    Controller2D controller;



    public float jumpX = 1f;
    public float JumpHeight = 4f;
    public float timeToJumpApex = .4f;

    float gravity;
    float jumpVelocity;
    float velocityXSmoothing;
    int stepCount;

    Text stepText;

    Vector2 input;
    Vector3 velocity;

	private void Awake()
	{
        step = speed * Time.deltaTime;

        controller = GetComponent<Controller2D>();
        GameObject numberOfStep = GameObject.FindGameObjectWithTag("NumberOfStep");
        stepText = numberOfStep.GetComponent<Text>();
        GameObject moveButton = GameObject.FindGameObjectWithTag("JumpButton");
        Button bnt = moveButton.GetComponent<Button>();
        bnt.onClick.AddListener(Jump);
	}

    private void Update()
    {
        CalculateGravity();

        stepText.text = stepCount.ToString();

        if(controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        if (startMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);

        }

        if(transform.position == newPosition)
        {
            startMove = false;
        }

        //float targetVelocity = input.x;
        //velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocity, ref velocityXSmoothing, .1f);
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
            stepCount++;
            newPosition = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            startMove = true;
            velocity.y = jumpVelocity;
            //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), smoothing * Time.deltaTime);
            //velocity.x = jumpX;
            controller.Move(velocity * Time.deltaTime);
            Debug.Log("jump");
        }
    }

}
