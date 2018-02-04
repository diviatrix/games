using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	public float gravity;	
	public GameObject plModel;
	public Vector3 movePoint;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();	
	}
	
	private void FixedUpdate() {

		rb.AddForce(Vector3.down*gravity);

		float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint, step);		
	}	
}
