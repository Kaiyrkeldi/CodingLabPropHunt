using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    private string remoteLayer = "RemotePlayer";
    private float currTimer;
    private Camera sceneCamera;
    private GameObject blackScreen;
    GameObject health;

    [SerializeField]
    Behaviour[] componentsToDisable;

    private RawImage crossHairImage;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
            gameObject.layer = LayerMask.NameToLayer(remoteLayer);
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
                sceneCamera.gameObject.SetActive(false);
        }
        crossHairImage = GameObject.Find("crossHairImage").GetComponent<RawImage>();
        health = GameObject.Find("healthText");
        if (isLocalPlayer)
        {
            health.SetActive(true);
            crossHairImage.enabled = true;
            blackScreen = GameObject.Find("GM").GetComponent<GameManager_References>().blackScreen;
            blackScreen.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
            Cursor.visible = true;
        else
            Cursor.visible = false;
        currTimer += 1 * Time.deltaTime;

        if (currTimer >= 30) { blackScreen.SetActive(false); }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();
        GameManager.RegisterPlayer(netID, player);
    }

    void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera.gameObject.SetActive(true);
        GameManager.UnRegisterPlayer(transform.name);
    }
}
