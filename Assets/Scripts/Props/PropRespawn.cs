using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class PropRespawn : NetworkBehaviour
{
    PropDeath prop;
    private Player healthScript;
    private GameObject respawnButton;
    public GameObject spawnpoint;
    public GameObject secondPlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Player>();
        healthScript.EventRespawn += EnablePlayer;
        SetRespawnButton();
    }

    void OnDisable()
    {
        healthScript.EventRespawn -= EnablePlayer;
    }
    void SetRespawnButton()
    {
            respawnButton = GameObject.Find("GM").GetComponent<GameManager_References>().RespawnButton;
            respawnButton.GetComponent<Button>().onClick.AddListener(EnablePlayer);
            respawnButton.SetActive(false);
    }

    void EnablePlayer()
    {
        healthScript.isDead = false;

        if (isLocalPlayer)
        {
            respawnButton.SetActive(false);
        }
    }

    void CommenceRespawn()
    {
        CmdRespawnOnServer();
    }

    [Command]
    void CmdRespawnOnServer()
    {
        healthScript.ResetHealth();
    }
}


