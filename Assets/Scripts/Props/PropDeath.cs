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

    private CounterClients counterClients;

    // Start is called before the first frame update
    void Start()
    {
        counterClients = GameObject.Find("Counter").GetComponent<CounterClients>();
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
            Camera.enabled = false;
            flyCamera.enabled = true;
            foreach (GameObject player in players)
            {
                SetLayerRecursively(player, 8);
            }
            GameObject.Find("GM").GetComponent<GameManager_References>().Heal.SetActive(false);
            PropMotor.healing = false;
            GameObject.Find("GM").GetComponent<GameManager_References>().WH.SetActive(false);
            PropMotor.wallHack = false;
            PropMotor.speedx2 = false;
            PropMotor.jumpx2 = false;
        }
        counterClients.CmdIncreaseDeadProps();
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
