using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
 
public class NetworkPlayer : NetworkBehaviour
{
    public bool isNetworkTimeSynced = false;

    public Text time;
    // timestamp received from server
    private int networkTimestamp;
 
    // server to client delay
    private int networkTimestampDelayMS;
 
    // when did we receive timestamp from server
    private float timeReceived;
 
    protected virtual void Start()
    {
        if (isLocalPlayer)
        {
            CmdRequestTime();
        }
        time = GameObject.Find("Text").GetComponent<Text>();
    }
    void Update()
    {
        if (GameManager.count >= 2)
        {
            int currtime = (int)GetServerTime();
            time.text = "Time: " + currtime.ToString();
        }
    }
    [Command]
    private void CmdRequestTime()
    {
        int timestamp = NetworkTransport.GetNetworkTimestamp();
        RpcNetworkTimestamp(timestamp);
    }
 
    [ClientRpc]
    private void RpcNetworkTimestamp(int timestamp)
    {
        isNetworkTimeSynced = true;
        networkTimestamp = timestamp;
        timeReceived = Time.time;
 
        // if client is a host, assume that there is 0 delay
        if (isServer)
        {
            networkTimestampDelayMS = 0;
        }
        else
        {
            byte error;
            networkTimestampDelayMS = NetworkTransport.GetRemoteDelayTimeMS(
                NetworkManager.singleton.client.connection.hostId,
                NetworkManager.singleton.client.connection.connectionId,
                timestamp,
                out error);
        }
    }
 
    public float GetServerTime()
    {
        return (networkTimestampDelayMS / 1000f) + (Time.time - timeReceived);
    }
}