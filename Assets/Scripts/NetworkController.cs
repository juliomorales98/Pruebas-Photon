using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks {

	// Use this for initialization
	void Start () {
		//Nos conectamos al mejor servidor
		PhotonNetwork.ConnectUsingSettings();
	}
	
	public override void OnConnectedToMaster(){
		//Nos dice a qué región estamos conectados
		Debug.Log("Conectados a " + PhotonNetwork.CloudRegion + " server");
		PhotonNetwork.AutomaticallySyncScene = true;
	}
}
