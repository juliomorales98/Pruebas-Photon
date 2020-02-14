using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PhotonPlayer : MonoBehaviour {

	private PhotonView PV;
	public GameObject myAvatar;
	// Use this for initialization
	void Start () {
		PV = GetComponent<PhotonView>();
		int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
		if(PV.IsMine){
			myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"),
			GameSetup.GS.spawnPoints[spawnPicker].position,
			GameSetup.GS.spawnPoints[spawnPicker].rotation,
			0);
			
			/*GameObject s = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonCamera"),
			GameSetup.GS.spawnPoints[spawnPicker].position,
			GameSetup.GS.spawnPoints[spawnPicker].rotation,
			0);
			
			Camera.SetupCurrent() = */

			GameObject camera = GameObject.FindWithTag ("MainCamera");
			if (camera != null)
			{
				CameraController followScript = camera.GetComponent("CameraController") as CameraController;
				if (followScript != null){
					followScript.target = myAvatar;
				}
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
