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
public class Struct_Item
{
    public int id; //道具id
    public int count; //数量

}


[Serializable]
public class Response_GetUserData
{
    public Struct_Item[] items; //道具列表
    public int[] methords; //收集的玩法
    public int status; //状态
    public string m; //错误信息
}

/*
public class Response_Error
{
    public Response_Error(string s)
    {

    }
}
*/