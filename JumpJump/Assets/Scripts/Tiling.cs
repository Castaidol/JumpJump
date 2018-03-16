using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiling : MonoBehaviour {

    public int offsetX = 2;
    public GameObject tile;
    public float maxPositionTileY = 2;
    public float minPositionTileY = -4;


    const float offsetY = 0.5f;

    private bool canGoUp;
    private bool canGoDown;
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
        BoxCollider2D tileBoxCollider = GetComponent<BoxCollider2D>();
        tileWidth = tileBoxCollider.bounds.size.x;
	}

	void Update () {
		
         float cameraHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
         float visibleEdgeRight = (myTransform.position.x + tileWidth / 2) - cameraHorizontalExtend;

        if (cam.transform.position.x >= visibleEdgeRight - offsetX && !hasABuddy)
        {
            CheckPositionTile();
            MakeANewTile(DefinePositionTileY());
            hasABuddy = true;
        }

	}

    void MakeANewTile(float offsety){

        Vector3 newPosition = new Vector3(myTransform.position.x + tileWidth, myTransform.position.y + offsety, myTransform.position.z);
        Instantiate(tile, newPosition, Quaternion.identity);
    }

    void CheckPositionTile()
    {
        if(myTransform.position.y < maxPositionTileY && myTransform.position.y > minPositionTileY)
        {
            canGoUp = true;
            canGoDown = true;
        }else if(myTransform.position.y == maxPositionTileY)
        {
            canGoUp = false;
            canGoDown = true;
        }else if(myTransform.position.y == minPositionTileY)
        {
            canGoUp = true;
            canGoDown = false;
        }
    }

    float DefinePositionTileY()
    {
        float r = Random.Range(0, 100);

        if(canGoUp && canGoDown)
        {
            if(r <= 40)
            {
                return 0;
            }
            else if(r > 40 && r < 70)
            {
                return offsetY;
            }
            else 
            {
                return -offsetY;
            }
        }

        else if (!canGoUp && canGoDown)
        {
            if (r <= 40)
            {
                return 0;
            }
            else
            {
                return -offsetY;
            }

        }

        else if (canGoUp && !canGoUp)
        {
            if (r <= 40)
            {
                return 0;
            }
            else
            {
                return offsetY;
            }

        } else
        {
            return 0;
        }
    }
}
