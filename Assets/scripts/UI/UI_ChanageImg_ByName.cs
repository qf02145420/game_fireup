using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UI_ChanageImg_ByName : MonoBehaviour {

    public Texture[] imgs;

    private Texture img;

    void start()
    {
        img = gameObject.GetComponent<Image>().sprite.texture;
    }

    public void SetScoreInfo(int id, int rank, int move, string val)
    {

    }
}
