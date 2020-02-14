/*
Inicializa el prefab para la conexión del servidor, no inicializa el avatar.
*/

using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
		CreatePlayer();
	}
	
	
	private void CreatePlayer(){
		Debug.Log("Creando jugador");
		PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PhotonPlayer"),Vector3.zero, Quaternion.identity);
	}
}
