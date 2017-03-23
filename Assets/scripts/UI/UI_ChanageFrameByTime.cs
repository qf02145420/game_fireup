using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChanageFrameByTime : MonoBehaviour {

    public Sprite[] imgs;
    public float frame_Time;
    public int imgPoint = 0;

    Image imgObj;
    float sumTime = 0;
    
    // Use this for initialization
    void Start () {
        imgObj = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        //sumTime
        sumTime += Time.deltaTime;
        if (sumTime > frame_Time)
        {
            sumTime = 0;
            imgPoint++;
            if (imgPoint == imgs.Length)
            {
                imgPoint = 0;
            }
            imgObj.sprite = imgs[imgPoint];
        }
    }
}
