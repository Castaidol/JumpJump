using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour {

    public int swordIndex;
    int currentIndex;
    //float offset = 0.01f;

	void Start () {
        //currentIndex = PlayerPrefs.GetInt("SwordIndex");
	}
	
	void Update () {
		/*
        currentIndex = PlayerPrefs.GetInt("SwordIndex");

        if(currentIndex == swordIndex)
        {
            Debug.Log("ciao");
        }*/


	}

	private void OnMouseOver()
	{
        if (Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetInt("SwordIndex", swordIndex);
            Debug.Log(PlayerPrefs.GetInt("SwordIndex"));
        }



	}
}
