using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArmor : MonoBehaviour {

    public bool nextArmor;
    int armorIndex;

	// Use this for initialization
	void Start () {
        armorIndex = PlayerPrefs.GetInt("KnightIndex");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (nextArmor) armorIndex++;
            else armorIndex--;

            if (armorIndex >= 5) armorIndex = 0;
            if (armorIndex <= -1) armorIndex = 4;

            PlayerPrefs.SetInt("KnightIndex", armorIndex);
            Debug.Log(PlayerPrefs.GetInt("KnightIndex"));
        }



    }
}
