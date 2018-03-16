using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    private Transform target;

	private void Awake()
	{
        GameObject knight = GameObject.FindGameObjectWithTag("Player");
        target = knight.GetComponent<Transform>();
	}

	void Update () {

        Vector3 newCameraPosition = new Vector3(target.position.x - transform.position.x, 0, 0);

        transform.Translate(newCameraPosition);
	}

   
}
