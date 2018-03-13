using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiling : MonoBehaviour {

    public int offsetx = 2;
    public GameObject tile;

    private bool hasABuddy = false;
    private float tileWidth = 0f;
    private Camera cam;
    private Transform myTransform;

	private void Awake()
	{
        myTransform = transform;
        cam = Camera.main;
	}

	private void Start()
	{
        SpriteRenderer tileSpriteRenderer = tile.GetComponent<SpriteRenderer>();
        tileWidth = tileSpriteRenderer.bounds.size.x;
	}

	void Update () {
		
         float cameraHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
         float visibleEdgeRight = (myTransform.position.x + tileWidth / 2) - cameraHorizontalExtend;

        if (cam.transform.position.x >= visibleEdgeRight - offsetx && !hasABuddy)
        {
            MakeANewTile();
            hasABuddy = true;
        }

	}

    void MakeANewTile(){

        Vector3 newPosition = new Vector3(myTransform.position.x + tileWidth, myTransform.position.y, myTransform.position.z);
        GameObject newBuddy = Instantiate(tile, newPosition, Quaternion.identity);
    }
}
