using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class ChooseWeapon : MonoBehaviour {

    public SpriteMeshAnimation sword;


	// Use this for initialization
	void Start () {

        sword.frame = PlayerPrefs.GetInt("SwordIndex");
	}
	
	// Update is called once per frame
	void Update () {
		
        sword.frame = PlayerPrefs.GetInt("SwordIndex");
	}
}
