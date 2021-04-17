using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PropDeath : NetworkBehaviour
{
    private Player healthScript;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Player>();
        healthScript.EventDie += DisablePlayer;
    }
    void Update()
    {
        
    }
    void OnDisable()
    {
        healthScript.EventDie -= DisablePlayer;
    }

    void DisablePlayer()
    {
        GetComponent<CharacterController>().enabled = false;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in renderers)
            ren.enabled = false;

        healthScript.isDead = true;

        if (isLocalPlayer)
        {
            GameObject.Find("GM").GetComponent<GameManager_References>().RespawnButton.SetActive(true);
        }
    }
}
