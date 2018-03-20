using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Text healtText;
    int offset = 2;
    float jumpForce = 5;

    Vector2 speed;
    public int healt = 10;

	private void Start()
	{
        rb2d = GetComponent<Rigidbody2D>();
        speed = new Vector2(5, 0);

	}

	private void Update()
	{
        healtText.text = healt.ToString();

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 force = new Vector2(0, jumpForce);
            rb2d.AddForce(force, ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.MovePosition(rb2d.position + speed * Time.fixedDeltaTime);
        }


	}
}
