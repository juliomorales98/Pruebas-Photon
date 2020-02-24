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
		gameObject.GetComponent<PhotonView>().OwnershipTransfer = OwnershipOption.Takeover;
	}
	
	// Update is called once per frame
	void Update () {
		//messages = gameObject.GetComponent<Text>().text;
	}
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		//messages = gameObject.GetComponent<Text>().text;
		
		if(stream.IsWriting){
			//Debug.Log(msgText.text);
			stream.SendNext(msgText.text);
			//Debug.Log("W Read data = " + stream.M_GetReadData().ToString());
			//Debug.Log("writing info = " + info);
		}else{
			msgText.text = (string)stream.ReceiveNext();
			//Debug.Log("receiving info = " + info);
			//Debug.Log("R Read data = " + stream.M_GetReadData().ToString());
		}

		//Debug.Log("info = " + info);
	}
}
