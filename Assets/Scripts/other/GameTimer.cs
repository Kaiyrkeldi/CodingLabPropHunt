using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameTimer : NetworkBehaviour
{
    private const float howLong = 90;

    public float gameTime = 0; //The length of a game, in seconds.
    public float timer = -1; //How long the game has been running. -1=waiting for players, -2=game is done
    public bool roundIsStarted = false;
    public int points0 = 0;
    public int points1 = 0;

    [SerializeField] private GameObject SpawnButtons;

    private CounterClients counterClients;

    public Text timerText;
    public Text pointsText0;
    public Text pointsText1;


    [Command]
    public void CmdWhoWin()
    {
        if (roundIsStarted)
        {
            Debug.Log("hunters: " + counterClients.hunters + " props: " + counterClients.props);
            Debug.Log("Dead props: " + counterClients.deadProps + " Dead hunt: " + counterClients.deadHunters);
            if (counterClients.props - counterClients.deadProps <= 0 && counterClients.props != 0)
            {
                points0++;
                RpcShowWhoWin(points0, false);
                roundIsStarted = false;
                timer = -2;
            }
            else if (counterClients.hunters - counterClients.deadHunters <= 0 && counterClients.hunters != 0)
            {
                points1++;
                RpcShowWhoWin(points1, true);
                roundIsStarted = false;
                timer = -2;
            }
        }
    }
    [Command]
    public void CmdTimer(float timer)
    {
        if (timer <= gameTime && roundIsStarted)
        {
            timer = -2;
            roundIsStarted = false;
        }
        else if (timer == -1)
        {
            Debug.Log("hunters: "+ counterClients.hunters +" props: "+ counterClients.props);
            if ((counterClients.hunters + counterClients.props) >= 1)
            {
                timer = howLong;
                roundIsStarted = true;
            }
        }
        else if (timer == -2) //Game done.
        {
            counterClients.CmdResetAllCounters();
            RpcShowWhoWin(points1, true);
            RpcRestartRound();
            timer = -1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        this.timer = timer;
        RpcTimer(timer);
    }
    [ClientRpc]
    public void RpcRestartRound()
    {
        ClientScene.RemovePlayer(0);
        Cursor.visible = true;
        SpawnButtons.SetActive(true);
    }
    [ClientRpc]
    public void RpcShowWhoWin(int points, bool propHunt) //0 - hunter, 1 - prop; 
    {
        Text x = !propHunt ? (pointsText0) : (pointsText1);
        x.text = points.ToString();
    }

    [ClientRpc]
    public void RpcTimer(float timer)
    {
        if (timer < 0)
        {
            timer = 0;
        }

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void Start()
    {
        counterClients = GameObject.Find("Counter").GetComponent<CounterClients>();
    }
    void Update()
    {
        if (isServer)
        {
            CmdTimer(timer);
            CmdWhoWin();
        }
        if(timer <= 10)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Prop");
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