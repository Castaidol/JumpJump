using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidObstacle : MonoBehaviour {

    public GameObject firstSectorObstacle;

	void Start () {
        MakeATile();
	}
	
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        if(collision.tag == "Player")
        {
            StartCoroutine(AcidDamage());
        }

	}

    IEnumerator AcidDamage()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("danno");
    }

	void MakeATile()
    {
        Vector3 tilePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(firstSectorObstacle, tilePosition, Quaternion.identity);
    }
}
