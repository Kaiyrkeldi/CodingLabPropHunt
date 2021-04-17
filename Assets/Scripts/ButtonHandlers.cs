using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ButtonHandlers : MonoBehaviour {
	private GameObject spawnButtons;
	public customNetworkManager networkManager;
	void Start () {
		spawnButtons = GameObject.Find("SpawnButtons");
		var buttons = GetComponentsInChildren<Button> ();

		foreach (var button in buttons) {
			switch (button.gameObject.name) {
				case "SpawnPlayer1Button":
					button.onClick.AddListener (() => SpawnFirstPlayer ());
					break;
				case "SpawnPlayer2Button":
					button.onClick.AddListener (() => SpawnSecondPlayer ());
					break;
				case "SpawnPropVegetableBasketButton":
					button.onClick.AddListener(() => SpawnPropVegetableBasket());
					break;
				case "SpawnBasketButton":
					button.onClick.AddListener(() => SpawnBasket());
					break;
				case "SpawnMugButton":
					button.onClick.AddListener(() => SpawnMug());
					break;
				case "SpawnCupButton":
					button.onClick.AddListener(() => SpawnCup());
					break;
				case "SpawnSkinButton":
					button.onClick.AddListener(() => SpawnSkin());
					break;
				case "SpawnBoxButton":
					button.onClick.AddListener(() => SpawnBox());
					break;
				case "SpawnChairButton":
					button.onClick.AddListener(() => SpawnChair());
					break;
				case "SpawnPillowButton":
					button.onClick.AddListener(() => SpawnPillow());
					break;
			}
		}
	}

	void SpawnFirstPlayer () {
		PlayerInfoMessage msg = new PlayerInfoMessage (PlayerClass.first);
		var connection = NetworkManager.singleton.client.connection;
		ClientScene.AddPlayer (connection, 0, msg);
		spawnButtons.SetActive(false);
	}

	void SpawnSecondPlayer () {
		PlayerInfoMessage msg = new PlayerInfoMessage (PlayerClass.second);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log (connection);
		ClientScene.AddPlayer (connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnPropVegetableBasket()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.propVegetableBasket);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnBasket()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.basket);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnMug()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.mug);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnCup()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.cup);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnSkin()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.skin);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnBox()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.box);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnChair()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.chair);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}
	void SpawnPillow()
	{
		PlayerInfoMessage msg = new PlayerInfoMessage(PlayerClass.pillow);
		var connection = NetworkManager.singleton.client.connection;
		Debug.Log(connection);
		ClientScene.AddPlayer(connection, 0, msg);
		spawnButtons.SetActive(false);
	}


}