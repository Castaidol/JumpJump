using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour {

    public float waitTime;

    Rigidbody2D rb2D;


	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(FallingTime());
        }

    }

    IEnumerator FallingTime()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("mo cade");
        rb2D.gravityScale = 2f;
        rb2D.constraints = ~RigidbodyConstraints2D.FreezePositionY;
    }
}
