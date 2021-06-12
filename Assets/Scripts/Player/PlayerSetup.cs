using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    private string remoteLayer = "RemotePlayer";
    private float currTimer;
    private Camera sceneCamera;
    private GameObject blackScreen;
    private GameObject ProximityCheck;
    private TMP_Text blackText;
    private bool bs = true;

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
        if (isLocalPlayer)
        {
            GameObject.Find("GM").GetComponent<GameManager_References>().hud.SetActive(true);
            GameObject.Find("GM").GetComponent<GameManager_References>().crossHairImage.SetActive(true);
            GameObject.Find("GM").GetComponent<GameManager_References>().ProximityCheck.SetActive(true);
            blackScreen = GameObject.Find("GM").GetComponent<GameManager_References>().blackScreen;
            blackScreen.SetActive(true);
            blackText = GameObject.Find("blackText").GetComponent<TMP_Text>();
            GetComponent<PlayerMotor>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerShoot>().enabled = false;

        }

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (blackText != null)
        {
            currTimer += 1 * Time.deltaTime;

            if (!bs)
            {
                blackScreen.SetActive(false);
                GetComponent<PlayerMotor>().enabled = true;
                GetComponent<PlayerController>().enabled = true;
                GetComponent<PlayerShoot>().enabled = true;
                bs = false;
            }
            else if (bs)
            {
                if (currTimer >= 30) bs = false;
                blackText.text = "Wait " + ((int)(30 - currTimer)).ToString() + " seconds";
            }
        }
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
        //GameManager.UnRegisterPlayer(transform.name);
    }
}
