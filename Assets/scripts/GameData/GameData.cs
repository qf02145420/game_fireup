using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{


    public static UserData me;

    public static void LoadLocalData_GetInt(string key, int defval)
    {
        PlayerPrefs.GetInt(key, defval);
    }


    /// </summary>
    //public static string serverUrl = "http://192.168.3.64:8000/";
    public static string serverUrl = "http://www.outingball.com/";
    public static string token = string.Empty;
    public static int channel = 0;
    public static string Version { get { return _version; } }
    public static GameColor Color = new GameColor();
    public static string NewsNoticeAddress;
    public static string _version = "1.01";
    public static int platform;
    public static int os;
}
    
public class GameColor
{
    public Color Blue = new Color(0.34f, 0.43f, 0.76f, 1f);
    public Color Purple = new Color(0.58f, 0.21f, 0.86f, 1f);
    public Color Black = new Color(0f, 0f, 0f, 1f);
    public Color White = new Color(1f, 1f, 1f, 1f);
}