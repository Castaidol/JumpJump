using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class Select : MonoBehaviour {
    
    public Knight knight;

    Animator anim;
    bool isSelected;
    SpriteMeshAnimation sword;
    Transform spada;

	private void Awake()
	{
        isSelected = false;
        GameObject kg = knight.knight;
        GameObject newKg =  Instantiate(kg, this.transform.position, Quaternion.identity);
        newKg.transform.parent = this.transform;
        anim = newKg.GetComponent<Animator>();
	}


	private void OnMouseOver()
	{
        if(Input.GetMouseButtonDown(0))
        {
            isSelected = !isSelected;
            anim.SetBool("IsSelected", isSelected);
        }
	}
}
