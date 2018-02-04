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
	public GameObject plCam;	

	// protected override void NetworkStart()
	// {
	// 	base.NetworkStart();

	// 	if (!networkObject.IsOwner)
    //     {
	// 		return;
	// 	}

	// 	CreateCamera();
	// }	

	void Start()
	{
		CreateCamera();
	}

	private void CreateCamera()
	{
		
		plCam = new GameObject("plCam");
		plCam.AddComponent<Camera>();
		plCam.transform.Translate(0,defaultHeight,0);
		plCam.transform.Rotate(90,0,0); 
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

	private void FixedUpdate() 
	{

		// move camera to player object
		float step = camSpeed * Time.deltaTime;
		Vector3 moveVector = new Vector3(transform.position.x, plCam.transform.position.y, transform.position.z-camOffsetZ);
        plCam.transform.position = Vector3.MoveTowards(plCam.transform.position, moveVector, step);
		plCam.transform.LookAt(transform);

		// click to move and rotate
		if (Input.GetMouseButton(0))
		{
			LMB_click();
		}	


		// rotate camera when hold RMB
		if(Input.GetMouseButton(1))
		{
			plCam.transform.RotateAround (transform.position, new Vector3(0,Input.GetAxis("Mouse X") * 10,0), 3);
		}	

		// camera zoom in
        if (Input.GetAxis("Mouse ScrollWheel") < 0f ) 
		{
			if (plCam.transform.localPosition.y > minCamHeight)
			{
				plCam.transform.Translate(new Vector3(0,0,Input.GetAxis("Mouse ScrollWheel")*-zoomSensivity));
				currentHeight = plCam.transform.position.y;
			}
		}

		// camera zoom out
		if (Input.GetAxis("Mouse ScrollWheel") > 0f ) 
		{
			if (plCam.transform.localPosition.y < maxCamHeight)
			{
				plCam.transform.Translate(new Vector3(0,0,Input.GetAxis("Mouse ScrollWheel")*-zoomSensivity));
				currentHeight = plCam.transform.position.y;
			}
		}
	}
}
