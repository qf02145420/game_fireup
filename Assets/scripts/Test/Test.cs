using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CallBackTest(string s)
    {
        Debug.Log(s);
    }
    public void MyOnButtonClick()
    {
        ///StartCoroutine(HttpRequest.instence.HttpRequest_Get("check/","phone=15652038580", CallBackTest));
        Struct_Item si = new Struct_Item();
        si.id = 1;
        si.count = 2;

        Response_GetUserData rg = new Response_GetUserData();
        rg.items = new Struct_Item [2]{si,si};
        rg.methords = new int[3] { 1, 2, 3 };
        rg.status = 4;
        rg.m = "message";
        string json = JsonUtility.ToJson(rg);
        

        //WWWForm wf = new WWWForm();
        //wf.AddField


        
        Debug.Log(json);
        StartCoroutine(HttpRequest.instence.HttpRequest_Post("user/show", json, CallBackTest));

    }
}
