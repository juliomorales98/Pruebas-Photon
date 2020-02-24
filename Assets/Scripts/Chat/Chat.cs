using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;



public class Chat : MonoBehaviour{
	private string message;

	private Text messages;

	private InputField msgInput;

	private PhotonView myPV;

	void Start(){
		myPV = gameObject.GetComponent<PhotonView>();
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("ChatObject")){
			if(go.name == "Messages")
				messages = go.GetComponent<Text>();
				
			
			if(go.name == "msgInputField"){
				msgInput = go.GetComponent<InputField>();
			}
		}
	}

	void Update(){
		if(Input.GetKey(KeyCode.Return) && msgInput.text != ""){
			SendMessage();
		}
	}

	public void SendMessage(){

		/*if(!myPV.IsMine)
			return;*/

		if(msgInput.text == "")
			return;
		message = "\n" + PhotonNetwork.NickName + ": " + msgInput.text;
		msgInput.text = "";
		messages.GetComponent<PhotonView>().RequestOwnership();
		myPV.RPC("RPC_AddMessage", RpcTarget.AllBuffered, message);
		
	}

	[PunRPC]
	private void RPC_AddMessage(string msg){
		
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("ChatObject")){
			if(go.name == "Messages")
				messages = go.GetComponent<Text>();
			
			if(go.name == "msgInputField"){
				msgInput = go.GetComponent<InputField>();
			}
		}
		messages.text +=  message;

		/*Debug.Log("Hizo rpc");
		Debug.Log("Message = " + message);*/
	}
}
