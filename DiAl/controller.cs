using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	public float speed;
	Rigidbody2D playerrb;

	// Use this for initialization
	void Start () {
		playerrb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
		{
			MoveLeft();
		}

		if (Input.GetKey(KeyCode.D))
		{
			MoveRight();
		}

		if (Input.GetKey(KeyCode.W))
		{
			MoveUp();
		}
		if (Input.GetKey(KeyCode.S))
		{
			MoveDown();
		}
	}

	public void MoveLeft()
	{
		playerrb.AddForce(Vector2.left * speed);
	}
	public void MoveRight()
	{
		playerrb.AddForce(Vector2.right * speed);
	}
	public void MoveUp()
	{
		playerrb.AddForce(Vector2.up * speed);
	}
	public void MoveDown()
	{
		playerrb.AddForce(Vector2.down * speed);
	}
}
