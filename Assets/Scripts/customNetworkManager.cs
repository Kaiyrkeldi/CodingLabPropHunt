﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class customNetworkManager : NetworkManager
{
	private GameObject crossHair;
	private GameObject health;
	private GameObject SpawnButtons;
	private GameObject blackScreen;

<<<<<<< HEAD
	public GameObject firstPlayerPrefab, secondPlayerPrefab, propVegetableBasket,basket,mug;
=======
	public GameObject firstPlayerPrefab, secondPlayerPrefab, propVegetableBasket,basket,mug,cup,skin,box,chair,pillow;
>>>>>>> 399dc667145c7b86349a0c5f3429be9c6a8bf1cf

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		SpawnButtons = GameObject.Find("SpawnButtons");
		SpawnButtons.SetActive(false);
		blackScreen = GameObject.Find("GM").GetComponent<GameManager_References>().blackScreen;
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessagereader)
	{
		PlayerInfoMessage msg = extraMessagereader.ReadMessage<PlayerInfoMessage>();
		Debug.Log(msg.playerClass);
		GameObject playerPrefab = spawnPlayerFromClass(msg.playerClass);
		NetworkServer.AddPlayerForConnection(conn, playerPrefab, playerControllerId);
	}

	public override void OnStartClient(NetworkClient client)
	{
		base.OnStartClient(client);
		SpawnButtons.SetActive(true);
		blackScreen.SetActive(false);
	}

	public override void OnStopClient()
	{
		base.OnStopClient();
		SpawnButtons.SetActive(false);
		Cursor.visible = true;
		blackScreen.SetActive(false);
	}

	public GameObject spawnPlayerFromClass(PlayerClass playerClass)
	{
		GameObject playerPrefab = null;
		switch (playerClass)
		{
			case PlayerClass.first:
				playerPrefab = firstPlayerPrefab;
				return GameObject.Instantiate(playerPrefab, new Vector3(0,0,-5), Quaternion.identity);
				break;
			case PlayerClass.second:
				playerPrefab = secondPlayerPrefab;
				return GameObject.Instantiate(playerPrefab, new Vector3(92, 1, 107), Quaternion.identity);
				break;
			case PlayerClass.propVegetableBasket:
				playerPrefab = propVegetableBasket;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;
			case PlayerClass.basket:
				playerPrefab = basket;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;
			case PlayerClass.mug:
				playerPrefab = mug;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;
<<<<<<< HEAD
=======
			case PlayerClass.cup:
				playerPrefab = cup;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;
			case PlayerClass.skin:
				playerPrefab = skin;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;	
			case PlayerClass.box:
				playerPrefab = box;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;
			case PlayerClass.chair:
				playerPrefab = chair;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;
			case PlayerClass.pillow:
				playerPrefab = pillow;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 1, 50), Quaternion.identity);
				break;
>>>>>>> 399dc667145c7b86349a0c5f3429be9c6a8bf1cf
		}
		return GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

	}

}