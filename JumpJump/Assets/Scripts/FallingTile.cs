﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour {

    public float fallingSpeed = 1;
    public float secondToWait = 2.5f;

    private bool canFall = false;

	private void Update()
	{
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(WaitBeforeFall(secondToWait));
        }

        if(canFall)
        {
            transform.Translate(Vector3.down * fallingSpeed);
        }
	}

    IEnumerator WaitBeforeFall(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canFall = true;
    }

}
