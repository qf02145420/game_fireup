using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Item
{
    public Item()
    {
    }
}

public class ScoreData
{
    public string score_Value;
    public bool score_Up;
    public int score_Rank;
}
public class UserData
{
    public int userID = 100;
    public ScoreData time_Score;
    public ScoreData fun_Score;
    public BackpackData backpack = null;

    public void UpdateUserData(BackpackData bd)
    {
        backpack = bd;
    }

    public void GetLocalData(string key)
    {
        
    }
}

public class GamePlaneData
{
    public float GamePlane_Top;
    public float GamePlane_Left;
    public float GamePlane_Bottom;
    public float GamePlane_Right;

    public Vector3 cameraPos;
    public int cameraAngel;


    public GamePlaneData()
    {
        //3:4 = 0.75;
        //9:16 = 0.5625
        //2:3 = 0.667

        float p = Screen.width * 1.0f / Screen.height;
        if (p > 0.74f && p < 0.76f)
        {
            cameraPos = new Vector3(0, 0, 0);
            GamePlane_Top = 27;
            GamePlane_Left = -10;
            GamePlane_Bottom = -7;
            GamePlane_Right = 10;
            cameraAngel = 32;
        }
        else if (p > 0.65f && p < 0.67f)
        {
            cameraPos = new Vector3(0, -5f, 0);
            GamePlane_Top = 27f;
            GamePlane_Left = -10;
            GamePlane_Bottom = -6f;
            GamePlane_Right = 10;
            cameraAngel = 36;
        }
        else if (p > 0.55f && p < 0.57f)
        {
            cameraPos = new Vector3(0, -8f, 0);
            GamePlane_Top = 27;
            GamePlane_Left = -10;
            GamePlane_Bottom = -6;
            GamePlane_Right = 10;
            cameraAngel = 40;
        }
        else
        {
            cameraPos = new Vector3(0, -8f, 0);
            GamePlane_Top = 27;
            GamePlane_Left = -10;
            GamePlane_Bottom = -5;
            GamePlane_Right = 10;
            cameraAngel = 40;
        }
    }
}
