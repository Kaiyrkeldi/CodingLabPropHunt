using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PropDeath : NetworkBehaviour
{
    private Player healthScript;
    public GameObject secondPlayerPrefab;
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
        RpcSpawnPlayer();
    }
    [ClientRpc]
    void RpcSpawnPlayer()
    {
        var conn = GetComponent<NetworkIdentity>().connectionToClient;
        var newPlayer = Instantiate<GameObject>(secondPlayerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(GetComponent<NetworkIdentity>().gameObject);
        NetworkServer.ReplacePlayerForConnection(conn, newPlayer, 0);
    }
}
