using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersDB : MonoBehaviour {

    public static string[] player;
    IEnumerator Start()
    {
        WWW players = new WWW("http://bymy.org/scgi-bin/PlayersData.php");
        yield return players;
        string playersDataString = players.text;
        player = playersDataString.Split(';');
    }

    public static IEnumerator ResetBD()
    {
        WWW players = new WWW("http://bymy.org/scgi-bin/PlayersData.php");
        yield return players;
        string playersDataString = players.text;
        player = playersDataString.Split(';');
    }
    public static string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
            value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
