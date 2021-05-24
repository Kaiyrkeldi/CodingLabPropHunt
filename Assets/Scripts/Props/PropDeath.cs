using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PropDeath : NetworkBehaviour
{
    private Player healthScript;
    public GameObject secondPlayerPrefab;
    public Camera Camera;
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
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<PropMotor>().enabled = false;
        GetComponent<PropController>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        gameObject.tag = "Player";
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in renderers)
            ren.enabled = false;
        if (isLocalPlayer)
        {
            GameObject.Find("HUD").SetActive(false);
            Camera.enabled = false;
            flyCamera.enabled = true;
        }
    }
}
