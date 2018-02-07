using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public Rigidbody rb;
	public Animator playerAnimator;
	public float speed;
	public float gravity;	
	public GameObject plModel;
	public Vector3 movePoint;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		playerAnimator = plModel.GetComponent<Animator>();
	}
	
	private void FixedUpdate() {

		// fake gravity
		rb.AddForce(Vector3.down*gravity);

		// always move to this point
		float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint, step);	
		

		// animation control
		if(transform.position.x != movePoint.x || transform.position.z != movePoint.z)
		{
			Debug.Log("moving");
			playerAnimator.SetBool("isMoving", true);
		}
		else
		{
			Debug.Log("not moving");
			playerAnimator.SetBool("isMoving", false);
		}
	}	
}
