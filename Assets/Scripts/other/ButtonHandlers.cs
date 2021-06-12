using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ButtonHandlers : NetworkBehaviour {
	public GameObject spawnButtons;
	public customNetworkManager networkManager;

	public CounterClients counterClients;
	void Start () {
		//spawnButtons = GameObject.Find("SpawnButtons");
		var buttons = GetComponentsInChildren<Button> ();

		foreach (var button in buttons) {
			switch (button.gameObject.name) {
				case "SpawnPlayer1Button":
					button.onClick.AddListener (() => SpawnFirstPlayer ());
					break;
				case "SpawnPlayer2Button":
					button.onClick.AddListener (() => SpawnSecondPlayer ());
					break;
			}
		}
	}

	void SpawnFirstPlayer () {
		PlayerInfoMessage msg = new PlayerInfoMessage (PlayerClass.first);
		var connection = NetworkManager.singleton.client.connection;
		ClientScene.AddPlayer (connection, 0, msg);
		counterClients.CmdIncreaseProps();
		spawnButtons.SetActive(false);
	}

	void SpawnSecondPlayer () {
		PlayerInfoMessage msg = new PlayerInfoMessage (PlayerClass.second);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log (connection);
		ClientScene.AddPlayer (connection, 0, msg);
		counterClients.CmdIncreaseHunters();
		spawnButtons.SetActive(false);
	}
}