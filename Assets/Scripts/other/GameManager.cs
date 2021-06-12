using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int count = 0;
    private const string PLAYER_ID = "Player ";
    private static Dictionary<string, Player> players = new Dictionary<string, Player> ();

    public static void RegisterPlayer(string _netID, Player player)
    {
        string playerID = PLAYER_ID + _netID;
        players.Add(playerID, player);
        player.transform.name = playerID;
        count += 1;
    }

    public static void UnRegisterPlayer(string playerID)
    {
        players.Remove(playerID);
    }

    public static Player GetPlayer(string playerID)
    {
        return players[playerID];
    }
    public static int GetCounter()
    {
        return players.Count;
    }
    public static void ClearListPlayers()
    {
        players.Clear();
    }
    public static Player GetRandomPlayer()
    {
        int num = Random.Range(1, count+1);
        string RandomPlayer = "Player " + num.ToString();
        return players[RandomPlayer];
    }
}
