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

        //StartCoroutine(HttpRequest.instence.HttpRequest_Post("user/show", json, CallBackTest));

    }
}
