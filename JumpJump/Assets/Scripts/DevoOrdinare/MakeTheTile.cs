using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTheTile : MonoBehaviour {

    public GameObject[] tilesPrefs;

    Transform[] tileTrans = new Transform[4];

	void Start () {
        inizializeArray();
        CreateTheTile();
	}
	
	
	void Update () {
		
	}

    void CreateTheTile()
    {
        


        for (int i = 0; i <= 3; i++ )
        {
            Instantiate(tilesPrefs[Random.Range(0, 10)], tileTrans[i].position, Quaternion.identity);
        }
    }

    void inizializeArray()
    {
        Transform t1 = transform.Find("T1").transform;
        Transform t2 = transform.Find("T2").transform;
        Transform t3 = transform.Find("T3").transform;
        Transform t4 = transform.Find("T4").transform;

        tileTrans[0] = t1;
        tileTrans[1] = t2;
        tileTrans[2] = t3;
        tileTrans[3] = t4;

    }
}
