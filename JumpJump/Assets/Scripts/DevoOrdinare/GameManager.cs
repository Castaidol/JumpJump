using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] knights;

    private int startingChar;

	private void Awake()
	{
        startingChar = PlayerPrefs.GetInt("Character");
        Instantiate(knights[startingChar], transform.position, Quaternion.identity);
	}

	void Start () {
		
	}
	
	
	void Update () {
		
	}
}
