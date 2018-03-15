using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour {

    public int offsetx = 3;

    private float leftEdgeDestroy;
    private Camera cam;
    private Transform myTransform;

	private void Awake()
	{
        cam = Camera.main;
        myTransform = transform;
        BoxCollider2D tileBoxCollider = GetComponent<BoxCollider2D>();
	}

	
	void Update () {
        DestroyThisTile();
	}

    void DestroyThisTile()
    {
        float cameraHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

        leftEdgeDestroy = cam.transform.position.x - cameraHorizontalExtend - offsetx;

        if (myTransform.position.x <= leftEdgeDestroy)
        {
            Destroy(gameObject);
        }
    }

}
