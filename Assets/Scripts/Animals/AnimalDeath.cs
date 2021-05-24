using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AnimalDeath : NetworkBehaviour
{
    private Player healthScript;
    public GameObject secondPlayerPrefab;
    public GameObject Camera;
    public Camera flyCamera;
    private GameObject respawnButton;

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
        //        healthScript.isDead = true;
        Camera.SetActive(false);
        GetComponent<CharacterController>().enabled = false;
        GetComponent<HorseMovement>().enabled = false;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in renderers)
            ren.enabled = false;
        if (isLocalPlayer)
        {
            gameObject.tag = "Player";
            GameObject.Find("HUD").SetActive(false);
            flyCamera.enabled = true;
        }
    }
}
