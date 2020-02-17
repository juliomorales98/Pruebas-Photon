using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MenuController : MonoBehaviour {

	public static MenuController MC;

	public static bool[] pickeados = {false,false};
	void Start(){
		if(MenuController.MC == null){
			MenuController.MC = this;
		}else{
			if(MenuController.MC != this){
				Destroy(MenuController.MC.gameObject);
				MenuController.MC = this;
			}
		}
	}
	public void OnClickCharacterPick(int whichCharacter){
		if(PlayerInfo.PI != null){
			if(!pickeados[whichCharacter]){
				PlayerInfo.PI.mySelectedCharacter = whichCharacter;
				PlayerPrefs.SetInt("MyCharacter",whichCharacter);
				pickeados[whichCharacter] = true;
			}else{
				Debug.Log("Caracter ya pickeado");
			}
			
			
		}
	}

	[PunRPC]
	void RPC_GetSelected(){
		Debug.Log("Rojo = " + pickeados[0].ToString());
		Debug.Log("Azul = " + pickeados[1].ToString());
	}
}
