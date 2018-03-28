using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightAnimTest : MonoBehaviour {

    bool isSelected = true;


    Animator anim;
    public bool isTheGameStarted = false;

	private void Awake()
	{
        anim = GetComponent<Animator>();


	}

	

	void Update()
    {
        if (isSelected)
        {
            anim.SetBool("IsSelected", true);
        }
    }
}
