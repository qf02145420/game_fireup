using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameLogic
{
    public static void NetCall_GetUserData()
    {
        string str = "token=" + GameData.token + "&channel=" + GameData.channel.ToString();
        HttpRequest.instence.HttpRequest_Get("Request_GetUserData", str, NetCallBack_GetUserData);
    }
    public static void NetCallBack_GetUserData(string jsondata)
    {

    }
}
