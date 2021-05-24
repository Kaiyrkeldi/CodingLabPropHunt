using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameTimer : NetworkBehaviour
{
    private const float howLong = 90;

    [SyncVar] public float gameTime = 0; //The length of a game, in seconds.
    [SyncVar] public float timer = howLong; //How long the game has been running. -1=waiting for players, -2=game is done
    [SyncVar] public bool roundIsStarted = false;

    public Text timerText;

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
            if (GameManager.GetCounter() >= 4)
            {
                timer = howLong;
                roundIsStarted = true;
            }
        }
        else if (timer == -2 || !roundIsStarted)
        {
            //Game done.
            timer = -1;
        }
        else
        {
            timer -= Time.deltaTime;
            roundIsStarted = true;
        }
        this.timer = timer;
        RpcTimer(timer);
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
    public void ResetTimer()
    {
        this.timer = howLong;
        this.roundIsStarted = false;
    }
    void Start()
    {
        timerText = GameObject.Find("HUD/Timer/timerText").GetComponent<Text>();
    }
    void Update()
    {
        CmdTimer(timer);
    }
}

