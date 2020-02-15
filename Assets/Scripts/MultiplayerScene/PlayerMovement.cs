using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private PhotonView PV;
	private CharacterController myCC;
	public float movementSpeedMio;
	public float rotationSpeedMio;

	private GameObject avatar;

	private Camera camera;
	[SerializeField]
	private Camera mainCamera;

	// Use this for initialization
	void Start () {
		PV = GetComponent<PhotonView>();
		myCC = GetComponent<CharacterController>();
		Debug.Log(transform.GetChild(1));
		camera = transform.GetChild(1).GetComponent<Camera>();
		camera.enabled = false;
		camera.enabled = true;
		
		mainCamera = Camera.main;
		if(!PV.IsMine){
			Destroy(mainCamera);
			Debug.Log("Destruyó camara");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(PV.IsMine){
			//Debug.Log("Is Mine");
			camera.enabled = false;
			camera.enabled = true;
			BasicMovement();
			BasicRotation();
		}else{
			/*foreach( GameObject c in GameObject.FindGameObjectsWithTag("MainCamera")){
				if(c != transform.GetChild(1)){
					Destroy(c);
					break;
				}
			}*/
			//Destroy(GameObject.FindGameObjectsWithTag("MainCamera"));
		}
	}

	void BasicMovement(){
		if(Input.GetKey(KeyCode.W)){
			myCC.Move(transform.forward * Time.deltaTime * movementSpeedMio);
			//Debug.Log("w");
		}

		if(Input.GetKey(KeyCode.A)){
			myCC.Move(-transform.right * Time.deltaTime * movementSpeedMio);
			//Debug.Log("a");
		}

		if(Input.GetKey(KeyCode.S)){
			myCC.Move(-transform.forward * Time.deltaTime * movementSpeedMio);
			//Debug.Log("s");
		}

		if(Input.GetKey(KeyCode.D)){
			myCC.Move(transform.right * Time.deltaTime * movementSpeedMio);
			//Debug.Log("d");
		}
	}

	void BasicRotation(){
		float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeedMio;
		transform.Rotate(new Vector3(0, mouseX, 0));
	}
}
