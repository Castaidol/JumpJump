using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightAttack : MonoBehaviour {

    Animator anim;
    [HideInInspector]
    public BoxCollider2D boxCol2D;
    Button btn;
	
	void Start ()
    {
        boxCol2D = GetComponent<BoxCollider2D>();
        boxCol2D.enabled = false;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        btn = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
        btn.onClick.AddListener(Attack);
	}
	
	
	void Attack()
    {
        boxCol2D.enabled = true;
        anim.SetTrigger("IsAttacking");
        StartCoroutine("Wait");
    }



    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        boxCol2D.enabled = false;
    }
}
