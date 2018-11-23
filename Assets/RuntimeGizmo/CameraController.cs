using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float lookSpeedH = 2f;
	public float lookSpeedV = 2f;
	public float zoomSpeed = 2f;
	public float dragSpeed = 6f;

	private float yaw = 0f;
	private float pitch = 0f;

	void Update ()
	{
		if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(2)) {
			transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed,   -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed, 0);
		}
		else if (Input.GetMouseButton(1))
		{
			yaw += lookSpeedH * Input.GetAxis("Mouse X");
			pitch -= lookSpeedV * Input.GetAxis("Mouse Y");

			transform.eulerAngles = new Vector3(pitch, yaw, 0);
		}

		transform.Translate(Input.GetAxis("Horizontal")* Time.deltaTime * dragSpeed, 0, 0);
		transform.Translate(0, Input.GetAxis("Vertical")* Time.deltaTime * dragSpeed, 0);

		//Zoom in and out with Mouse Wheel
		transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, Space.Self);
	}
}
