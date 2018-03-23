using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingTile : MonoBehaviour {

    public float magnitude = 0.3f;
    public float shakingTime = 1.5f;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed <= duration)
        {
            float x = Random.Range(-1.0f, 1.0f) * magnitude;

            transform.localPosition = new Vector3(x, originalPosition.y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPosition;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        StartCoroutine(Shake(shakingTime, magnitude));
	}
}
