using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CreatePlayer();
	}
	
	// Update is called once per frame
	private void CreatePlayer(){
		Debug.Log("Creando jugador");
		PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PhotonPlayer"),Vector3.zero, Quaternion.identity);
	}
}
