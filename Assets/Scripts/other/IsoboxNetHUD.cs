using System;
using System.ComponentModel;
using UnityEngine.UI;

namespace UnityEngine.Networking
{
	//[AddComponentMenu("Network/NetworkManagerHUD")]
	[RequireComponent(typeof(NetworkManager))]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class IsoboxNetHUD : MonoBehaviour
	{
		public NetworkManager manager;


		void Awake()
		{
			manager = GetComponent<NetworkManager>();
		}

		void Update()
		{
			if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
			{
				if (Input.GetKeyDown(KeyCode.S))
				{
					manager.StartServer();
				}
				if (Input.GetKeyDown(KeyCode.H))
				{
					manager.StartHost();
				}
				if (Input.GetKeyDown(KeyCode.C))
				{
					manager.StartClient();
				}
			}
			if (NetworkServer.active && NetworkClient.active)
			{
				if (Input.GetKeyDown(KeyCode.X))
				{
					manager.StopHost();
				}
			}
		}

		public void StartupHost()
		{
			manager.StartHost();
			GameObject.Find("GM").GetComponent<GameManager_References>().ProximityCheck.SetActive(false);
			GameObject.Find("GM").GetComponent<GameManager_References>().crossHairImage.SetActive(false);
			GameObject.Find("GM").GetComponent<GameManager_References>().menu.SetActive(false);
			GameObject.Find("GM").GetComponent<GameManager_References>().Lobby.SetActive(false);
		}

		public void JoinGame()
		{
			SetIpAddress();
			manager.StartClient();
		}

		public void SetIpAddress()
		{
			string ipAddress = GameObject.Find("InputField").transform.Find("Text").GetComponent<Text>().text;
			manager.networkAddress = ipAddress;
		}

		public void DedicatedServer()
        {
			manager.StartServer();

        }
		public void Disconnect()
		{
			manager.StopClient();
			manager.StopHost();
		}
	}
};