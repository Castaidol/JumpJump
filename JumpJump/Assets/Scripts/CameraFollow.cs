using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform target;

	void Update () {

         Vector3 newCameraPosition = new Vector3(target.position.x - transform.position.x, 0, 0);

        transform.Translate(newCameraPosition);
	}

   
}
