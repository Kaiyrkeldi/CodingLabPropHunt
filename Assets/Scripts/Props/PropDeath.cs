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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Prop");
        
        //        healthScript.isDead = true;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Rigidbody>().transform.position = Vector3.zero;
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
            GameObject.Find("GM").GetComponent<GameManager_References>().hud.SetActive(false);
            Camera.enabled = false;
            flyCamera.enabled = true;
            foreach (GameObject player in players)
            {
                SetLayerRecursively(player, 8);
            }
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
