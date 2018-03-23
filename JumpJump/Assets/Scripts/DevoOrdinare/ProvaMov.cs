using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaMov : MonoBehaviour {


    //public float smoothing = 1f;
    public float speed = 5;
    float step;
    Vector3 newPosition;
    bool move = false;

	private void Start()
	{
        step = speed * Time.deltaTime;
        newPosition = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
	}

	
	
	void FixedUpdate () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Move();  
        }

        if(move){
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        }

	}

    void Move()
    {
        move = true;
        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), smoothing * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, newPosition , step);
    }
}


/*
public Transform target;
public float speed;
void Update()
{
    float step = speed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
}
}*/