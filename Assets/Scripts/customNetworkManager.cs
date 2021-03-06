using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class customNetworkManager : NetworkManager
{
	private GameObject crossHair;
	private GameObject health;
	private GameObject SpawnButtons;
	private GameObject blackScreen;
	private GameObject minimap;
	private GameObject Audio;
	GameObject playerPrefab;

	public GameObject firstPlayerPrefab, secondPlayerPrefab, propVegetableBasket,basket,mug, cup, skin, box, chair, pillow;


	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		SpawnButtons = GameObject.Find("SpawnButtons");
		SpawnButtons.SetActive(false);
		blackScreen = GameObject.Find("GM").GetComponent<GameManager_References>().blackScreen;
		GameObject.Find("GM").GetComponent<GameManager_References>().ProximityCheck.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().crossHairImage.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().menu.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().Lobby.SetActive(true);
		Audio = GameObject.Find("Audio_Manager");

	}
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessagereader)
	{
		PlayerInfoMessage msg = extraMessagereader.ReadMessage<PlayerInfoMessage>();
		Debug.Log(msg.playerClass);
		if(msg.playerClass == PlayerClass.second) { 
		 playerPrefab = spawnPlayerFromClass(msg.playerClass);
		}
        else
        {
			playerPrefab = spawnPlayerRandom();
		}
		GameObject.Find("GM").GetComponent<GameManager_References>().crossHairImage.SetActive(true);
		GameObject.Find("GM").GetComponent<GameManager_References>().Lobby.SetActive(false);
		NetworkServer.AddPlayerForConnection(conn, playerPrefab, playerControllerId);
	}

	public override void OnStartClient(NetworkClient client)
	{
		base.OnStartClient(client);
		SpawnButtons.SetActive(true);
		blackScreen.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().crossHairImage.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().menu.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().Lobby.SetActive(false);
		Audio.SetActive(false);
	}

	public override void OnStopClient()
	{
		base.OnStopClient();
		SpawnButtons.SetActive(false);
		Cursor.visible = true;
		blackScreen.SetActive(false);
		GameManager.UnRegisterPlayer(transform.name);
		GameObject.Find("GM").GetComponent<GameManager_References>().ProximityCheck.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().crossHairImage.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().menu.SetActive(false);
		GameObject.Find("GM").GetComponent<GameManager_References>().Lobby.SetActive(true);
		Audio.SetActive(true);
	}

	public GameObject spawnPlayerFromClass(PlayerClass playerClass)
	{
		GameObject playerPrefab = null;
		playerPrefab = secondPlayerPrefab;
		return GameObject.Instantiate(playerPrefab, new Vector3(-4.3f, 1, 32.65f), Quaternion.identity);
	}

	public GameObject spawnPlayerRandom()
	{
		int num = Random.Range(1, 9);
		GameObject playerPrefab = null;
		switch (num)
		{
			case 1:
				playerPrefab = firstPlayerPrefab;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 2:
				playerPrefab = propVegetableBasket;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 3:
				playerPrefab = basket;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 4:
				playerPrefab = mug;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 5:
				playerPrefab = cup;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 6:
				playerPrefab = skin;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 7:
				playerPrefab = box;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 8:
				playerPrefab = chair;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 9:
				playerPrefab = pillow;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
		}
		return GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

	}

}