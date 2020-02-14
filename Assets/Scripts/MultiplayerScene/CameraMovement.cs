﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private PhotonView PV;
	private CharacterController myCC;
	public float movementSpeedMio;
	public float rotationSpeedMio;

	private GameObject avatar;

	// Use this for initialization
	void Start () {
		PV = GetComponent<PhotonView>();
		myCC = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PV.IsMine){
			BasicMovement();
			BasicRotation();
		}
	}

	void BasicMovement(){
		if(Input.GetKey(KeyCode.W)){
			myCC.Move(transform.forward * Time.deltaTime * movementSpeedMio);
			/*foreach(Transform child in transform){
				if(child.ToString() == "Camera (UnityEngine.Transform)" &&
				  child.GetComponent<PhotonView>().IsMine){
					Debug.Log("Esta es mi camara");
				}
				/*Debug.Log(child.ToString());
				Debug.Log(child.ToString() == "Camera (UnityEngine.Transform)");
			}*/
		}

		if(Input.GetKey(KeyCode.A)){
			myCC.Move(-transform.right * Time.deltaTime * movementSpeedMio);
		}

		if(Input.GetKey(KeyCode.S)){
			myCC.Move(-transform.forward * Time.deltaTime * movementSpeedMio);
		}

		if(Input.GetKey(KeyCode.D)){
			myCC.Move(transform.right * Time.deltaTime * movementSpeedMio);
		}
	}

	void BasicRotation(){
		float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeedMio;
		transform.Rotate(new Vector3(0, mouseX, 0));
	}
}