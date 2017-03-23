using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Image_SetTransparent : MonoBehaviour {

    public Image img;
	// Use this for initialization
	IEnumerator Start () {
        float sumtime = 0;
        int speed = 1;
        
        

        while (sumtime < 1)
        {
            sumtime += Time.deltaTime * speed;
            img.color = new Color(1, 1, 1, sumtime);
            yield return null;
        }
        img.color = new Color(1, 1, 1, 1);
        sumtime = 0;

        while (sumtime < 1)
        {
            sumtime += Time.deltaTime * speed;
            yield return null;
        }

        sumtime = 1;
        while (sumtime > 0)
        {
            sumtime -= Time.deltaTime * speed;
            img.color = new Color(1, 1, 1, sumtime);
            yield return null;
        }

        SceneManager.LoadScene("mainboard");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
