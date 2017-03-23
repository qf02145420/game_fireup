using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScoreBar : MonoBehaviour {

    public Texture[] imgs;
    public Text rank;
    public Image bgBar_me;
    public Image bgBar_other;
    public Image bgRank;
    public Text rankNum;
    public Text playerName;
    public Image iconChanage;
    public Text value;
    public Sprite[] imgss;

    private Texture img;

    void Start()
    {
        //img = gameObject.GetComponent<Image>().sprite.texture;
        //SetScoreInfo(1, 2, 1, "我是羊小鹿", "234");
    }

    public void SetScoreInfo(int id, int rank, int rankchanage, string name, string val)
    {
        //set bg bar
        if (GameData.me.userID == id)
        {
            bgBar_me.gameObject.SetActive(true);
            bgBar_other.gameObject.SetActive(false);
        }
        else
        {
            bgBar_me.gameObject.SetActive(false);
            bgBar_other.gameObject.SetActive(true);
        }

        //set rank bar
        switch (rank)
        {
            case 1:
                bgRank.sprite = imgss[0];
                break;
            case 2:
                bgRank.sprite = imgss[1];
                break;
            case 3:
                bgRank.sprite = imgss[2];
                break;
            default:
                bgRank.sprite = null;
                break;

        }

        //rank num
        if (rank < 3)
        {
            rankNum.gameObject.SetActive(false);
        }
        else
        {
            rankNum.text = rank.ToString();
        }
        //rank chanage
        switch (rankchanage)
        {
            case 0:
                iconChanage.sprite = imgss[3];
                break;
            case 1:
                iconChanage.sprite = imgss[4];
                break;
            default:
                iconChanage.gameObject.SetActive(false);
                break;
        }

        playerName.text = name;
        value.text = val;
    }
}
