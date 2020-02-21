﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CustomMatchmakingRoomController : MonoBehaviourPunCallbacks {

	[SerializeField]
	private int multiPlayerSceneIndex; //para cargar multiplayer scene

	[SerializeField]
	private GameObject lobbyPanel;

	[SerializeField]
	private GameObject roomPanel;

	[SerializeField]
	private GameObject startButton;

	[SerializeField]
	private Transform playersContainer;

	[SerializeField]
	private GameObject playerListingPrefab;

	[SerializeField]
	private Text roomNameDisplay;

	void ClearPlayerListing(){

		for( int i = playersContainer.childCount - 1; i >= 0; i--){
			Destroy(playersContainer.GetChild(i).gameObject);
		}

	}

	void ListPlayers(){
		foreach(Player player in PhotonNetwork.PlayerList){
			GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
			Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();

			tempText.text = player.NickName;

		}
	}

	public override void OnJoinedRoom(){
		roomPanel.SetActive(true);
		lobbyPanel.SetActive(false);
		roomNameDisplay.text = PhotonNetwork.CurrentRoom.Name;

		//Si es host puede inicial el juego
		if(PhotonNetwork.IsMasterClient){
			startButton.SetActive(true);

		}else{
			startButton.SetActive(false);
		}

		ClearPlayerListing();
		ListPlayers();
		PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerChat"),Vector3.zero, Quaternion.identity);
	}

	public override void OnPlayerEnteredRoom(Player newPlayer){
		ClearPlayerListing();
		ListPlayers();		
	}

	public override void OnPlayerLeftRoom(Player otherPlayer){
		ClearPlayerListing();
		ListPlayers();

		//Host migration
		//Validamos si el actual jugador se convirtió en host después de que este 
		//abandonara el room
		if(PhotonNetwork.IsMasterClient){
			startButton.SetActive(true);
		}
	}

	public void StartGame(){
		if(PhotonNetwork.IsMasterClient){
			PhotonNetwork.CurrentRoom.IsOpen = false; //Si está en false, jugadores ya no podrán unirse iniciado el juego
			PhotonNetwork.LoadLevel(multiPlayerSceneIndex);
		}
	}

	IEnumerator rejoinLobby(){
		yield return new WaitForSeconds(1);
		PhotonNetwork.JoinLobby();
	}

	public void BackOnClick(){
		//Para evitar errores con el host al regresar al room

		lobbyPanel.SetActive(true);
		roomPanel.SetActive(false);

		PhotonNetwork.LeaveRoom();
		PhotonNetwork.LeaveLobby();

		StartCoroutine(rejoinLobby());
	}


}
