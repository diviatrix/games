using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkCamera : MonoBehaviour
{
	public float sensivity;
	public float defaultHeight;
	public float minCamHeight;
	public float maxCamHeight;
	public float zoomSensivity;
	public float camSpeed;
	public float currentHeight;
	public float camOffsetZ;
	public Vector3 offset;

	// test
	public Vector3 _LocalRotation;

	public GameObject plCam;

	bool rotatingAround;

	void Start()
	{
		CreateCamera();
	}

	private void CreateCamera()
	{

		plCam = new GameObject("plCam");
		plCam.AddComponent<Camera>();
		plCam.transform.Translate(defaultHeight/2, defaultHeight, defaultHeight/2);
		plCam.transform.Rotate(45, 0, 0);
		plCam.transform.LookAt(transform);
		offset = plCam.transform.position - transform.position;
	}

	private void LMB_click()
	{
		// raycast from mouseclick on screen
		// get object
		// if hit walkable tag, tell controller to go there.
		RaycastHit hit;
		Ray ray = plCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
			if (hit.collider != null)
			{
				if (hit.transform.tag == "walkableArea")
				{
					//Debug.Log(hit.point + " " +  hit.transform.name);
					GetComponent<Controller>().plModel.transform.LookAt(hit.point);
					GetComponent<Controller>().movePoint = hit.point;
				}
			}
	}

	private void LateUpdate()
	{
		//float step = camSpeed * Time.deltaTime;
		plCam.transform.position = transform.position + offset;
		plCam.transform.LookAt(transform);

		//Vector3 moveVector = new Vector3(transform.position.x, plCam.transform.position.y, transform.position.z);
		//plCam.transform.position = Vector3.MoveTowards(plCam.transform.position, moveVector, step);
		//plCam.transform.position = transform.position + offset;

	}

	private void FixedUpdate()
	{
		// click to move and rotate
		if (Input.GetMouseButton(0))
		{
			LMB_click();
		}
		

		// rotate camera when hold RMB
		if (Input.GetMouseButton(1))
		{
			//plCam.transform.Rotate(transform.position, Input.GetAxis("Mouse Y")*sensivity, Space.Self);
			offset += Vector3.right;		
		}

		if (offset.y >= minCamHeight && Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			offset += new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * zoomSensivity, 0);
		}
		else if (offset.y <= maxCamHeight && Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			offset += new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * zoomSensivity, 0);
		}

	} 
	
}

