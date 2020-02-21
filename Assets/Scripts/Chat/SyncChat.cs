using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SyncChat : MonoBehaviourPunCallbacks, IPunObservable {
	private string messages;
	
	private Text msgText;
	// Use this for initialization
	void Start () {
		msgText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		//messages = gameObject.GetComponent<Text>().text;
	}
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		//messages = gameObject.GetComponent<Text>().text;
		if(stream.IsWriting){
			stream.SendNext(msgText.text);
		}else{
			this.messages = (string)stream.ReceiveNext();
			msgText.text = messages;
		}
	}
}
