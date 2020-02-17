using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PhotonPlayer : MonoBehaviour {

	private PhotonView PV;
	public GameObject myAvatar;

	public GameObject myCharacter;

	public int characterValue;
	

	// Use this for initialization
	void Start () {
		PV = GetComponent<PhotonView>();
		int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
		if(PV.IsMine){
			PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered,
			  PlayerInfo.PI.mySelectedCharacter);
			
			
			
		}
	}
	
	[PunRPC]
	void RPC_AddCharacter(int whichCharacter){
		characterValue = whichCharacter;

		myCharacter = Instantiate(PlayerInfo.PI.allCharacters[whichCharacter],
		transform.position, transform.rotation,
		null);
	}
}
