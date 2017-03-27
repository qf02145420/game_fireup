using UnityEngine;
using System.Collections;
using System;


[Serializable]
public class Request_Test
{
    public string phone = "15652038580";
    public Request_Test(string phonenumber)
    {
        phone = phonenumber;
    }
}

[Serializable]
public class BackpackItem
{
    public int id; //道具id
    public int count; //数量
    public int type; //道具类型
}

[Serializable]
public class BackpackData
{
    public BackpackItem[] backpack; //道具列表
    public FoundMethord[] methords; //收集的玩法
    public int status; //状态
    public string m; //错误信息
}

[Serializable]
public class FoundMethord
{
    public int[] ids; 
}

/*
public class Response_Error
{
    public Response_Error(string s)
    {

    }
}
*/
