using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomImage : MonoBehaviour {

    public GameObject[] bottom;

	void Start () {
        CreateBottom();
	}
	
	void CreateBottom()
    {
        if(bottom != null)
        {
            Instantiate(bottom[Random.Range(0, bottom.Length - 1)], transform.position, Quaternion.identity);
        }
    }
}
