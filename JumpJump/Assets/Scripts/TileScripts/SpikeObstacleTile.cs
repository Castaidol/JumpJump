using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObstacleTile : MonoBehaviour {

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
