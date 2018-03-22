using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {
    
    //public GameObject knight;
    public Knight knight;

    Animator anim;
    bool isSelected;

	private void Awake()
	{
        isSelected = false;
        GameObject kg = knight.knight;

        GameObject newKg =  Instantiate(kg, this.transform.position, Quaternion.identity);
        newKg.transform.parent = this.transform;
        anim = newKg.GetComponent<Animator>();
	}

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseOver()
	{
        Debug.Log("Son sopra");

        if(Input.GetMouseButtonDown(0))
        {
            isSelected = !isSelected;
            anim.SetBool("IsSelected", isSelected);
        }
	}
}
