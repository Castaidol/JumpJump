using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacleTiles : MonoBehaviour {

    public GameObject firstSectorObstacle;
   
    void Start()
    {
        MakeATile();
    }

    void MakeATile()
    {
        Vector3 tilePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(firstSectorObstacle, tilePosition, Quaternion.identity);
    }
}
