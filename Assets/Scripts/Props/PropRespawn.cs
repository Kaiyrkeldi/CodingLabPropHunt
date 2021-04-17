using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class PropRespawn : NetworkBehaviour
{
    private Player healthScript;
    private GameObject respawnButton;
    public GameObject spawnpoint;
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
            respawnButton.GetComponent<Button>().onClick.AddListener(CommenceRespawn);
            respawnButton.SetActive(false);
    }

    void EnablePlayer()
    {
        GetComponent<CharacterController>().enabled = true;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in renderers)
            ren.enabled = true;
        GetComponent<Rigidbody>().transform.position = spawnpoint.transform.position;

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
