using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class customNetworkManager : NetworkManager
{
	private GameObject crossHair;
	private GameObject health;
	public GameObject SpawnButtons;
	public GameObject blackScreen;
	private GameObject minimap;
	private GameObject Audio;
	public GameObject Lobby;
	public GameObject Perks;
	public GameObject Heal;
	public GameObject WH;
	public GameObject Join;
	public GameObject Options;
	GameObject playerPrefab;

	public GameObject firstPlayerPrefab, secondPlayerPrefab, propVegetableBasket, basket, mug, cup, skin, box, chair,
	pillow, pivo, bigBox, seno, axe, bottle, kotelok, stool, container, cauldron, barrel, pan, brushwood, bowl, bag;
	public Image myImageComponent;
	public Sprite basketSprite, boxSprite, chairSprite, cupSprite, mugSprite, pillowSprite, skinSprite, vegbasketSprite,
		pivoSprite, bigBoxSprite, senoSprite, axeSprite, bottleSprite, kotelokSprite, stoolSprite, containerSprite, cauldronSprite, barrelSprite, panSprite,
		brushwoodSprite, bowlSprite, bagSprite;


	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		//SpawnButtons = GameObject.Find("SpawnButtons");
		SpawnButtons.SetActive(false);
		Perks.SetActive(false);
		Audio = GameObject.Find("Audio_Manager");
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessagereader)
	{
		PlayerInfoMessage msg = extraMessagereader.ReadMessage<PlayerInfoMessage>();
		Debug.Log(msg.playerClass);
		if(msg.playerClass == PlayerClass.second) { 
			if(GameObject.FindGameObjectWithTag("Player") != null) { 
				playerPrefab = spawnPlayerRandom();
			}
			else
				playerPrefab = spawnPlayerFromClass(msg.playerClass);
		}
        else
        {
			playerPrefab = spawnPlayerRandom();
		}
		GameObject.Find("GM").GetComponent<GameManager_References>().crossHairImage.SetActive(true);
		GameObject.Find("GM").GetComponent<GameManager_References>().Lobby.SetActive(false);
		Perks.SetActive(false);
		NetworkServer.AddPlayerForConnection(conn, playerPrefab, playerControllerId);
	}

	public override void OnStartClient(NetworkClient client)
	{
		base.OnStartClient(client);
		SpawnButtons.SetActive(true);
		Lobby.SetActive(false);
		Audio.SetActive(false);
		Perks.SetActive(false);
		blackScreen.SetActive(false);
		Join.SetActive(false);
		Options.SetActive(false);
	}
    /*public override void OnStopServer()
    {
        base.OnStopServer();
		GameManager.UnRegisterPlayer(transform.name);
	}*/
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
		GameManager.ClearListPlayers();
	}
    public override void OnStopHost()
    {
        base.OnStopHost();
		GameManager.ClearListPlayers();
	}
    public override void OnStopClient()
	{
		base.OnStopClient();
		SpawnButtons.SetActive(false);
		Cursor.visible = true;
		GameManager.UnRegisterPlayer(transform.name);
		Lobby.SetActive(true);
		blackScreen.SetActive(false);
		Heal.SetActive(false);
		PropMotor.healing = false;
		WH.SetActive(false);
		PropMotor.wallHack = false;
		PropMotor.speedx2 = false;
		PropMotor.jumpx2 = false;
		GameObject.Find("GM").GetComponent<GameManager_References>().menu.SetActive(false);
		Audio.SetActive(true);
		Options.SetActive(true);
	}

	public GameObject spawnPlayerFromClass(PlayerClass playerClass)
	{
		GameObject playerPrefab = null;
		playerPrefab = secondPlayerPrefab;
		return GameObject.Instantiate(playerPrefab, new Vector3(-4.3f, 1, 32.65f), Quaternion.identity);
	}

	public GameObject spawnPlayerRandom()
	{
		int num = Random.Range(2, 20);
		GameObject playerPrefab = null;
		switch (num)
		{
			case 1:
				playerPrefab = firstPlayerPrefab;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 2:
				playerPrefab = propVegetableBasket;
				myImageComponent.sprite = vegbasketSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 3:
				playerPrefab = basket;
				myImageComponent.sprite = basketSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 4:
				playerPrefab = mug;
				myImageComponent.sprite = mugSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 5:
				playerPrefab = cup;
				myImageComponent.sprite = cupSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 6:
				playerPrefab = skin;
				myImageComponent.sprite = skinSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 7:
				playerPrefab = box;
				myImageComponent.sprite = boxSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 8:
				playerPrefab = chair;
				myImageComponent.sprite = chairSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 9:
				playerPrefab = pillow;
				myImageComponent.sprite = pillowSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 10:
				playerPrefab = pivo;
				myImageComponent.sprite = pivoSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 11:
				playerPrefab = bigBox;
				myImageComponent.sprite = bigBoxSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 12:
				playerPrefab = seno;
				myImageComponent.sprite = senoSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 13:
				playerPrefab = axe;
				myImageComponent.sprite = axeSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 14:
				playerPrefab = bottle;
				myImageComponent.sprite = bottleSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 15:
				playerPrefab = kotelok;
				myImageComponent.sprite = kotelokSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 16:
				playerPrefab = stool;
				myImageComponent.sprite = stoolSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 17:
				playerPrefab = container;
				myImageComponent.sprite = containerSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 18:
				playerPrefab = cauldron;
				myImageComponent.sprite = cauldronSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 19:
				playerPrefab = barrel;
				myImageComponent.sprite = barrelSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 20:
				playerPrefab = pan;
				myImageComponent.sprite = panSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
				break;
			case 21:
				playerPrefab = brushwood;
				myImageComponent.sprite = brushwoodSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 22:
				playerPrefab = bowl;
				myImageComponent.sprite = bowlSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
			case 23:
				playerPrefab = bag;
				myImageComponent.sprite = bagSprite;
				return GameObject.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
				break;
		}
		return GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

	}
}