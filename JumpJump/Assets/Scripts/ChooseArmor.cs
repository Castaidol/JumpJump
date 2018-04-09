using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class ChooseArmor : MonoBehaviour {

    public SpriteMeshAnimation armor;
	
	void Start () 
    {
        armor.frame = PlayerPrefs.GetInt("KnightIndex");
        //PlayerPrefs.SetInt("KnightIndex", 0);
	}
	
	
	void Update () 
    {
        armor.frame = PlayerPrefs.GetInt("KnightIndex");
	}
}
