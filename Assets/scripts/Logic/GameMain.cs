using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

    public void StartGame()
    {
        UI_Controller.instance.ChanageUIFace_SearchItem();
    }
    public IEnumerator Restart()
    {
        GameData.me = new UserData();
        GameLogic.NetCall_GetUserData();
        while (GameData.me.backpack == null)
        {
            yield return new WaitForSeconds(0.5f);
        }
        UI_Controller.instance.UIReset();
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(Restart());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
