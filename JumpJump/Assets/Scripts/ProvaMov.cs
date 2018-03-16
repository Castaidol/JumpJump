using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaMov : MonoBehaviour {

	
    public float smoothing = 1f;
	
	// Update is called once per frame
	void FixedUpdate () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Move();  
        }

	}

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), smoothing * Time.deltaTime);
    }
}
