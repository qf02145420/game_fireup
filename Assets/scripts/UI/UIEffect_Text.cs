using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIEffect_Text : MonoBehaviour {

    public float onTimeDestroy = 3;
    public int movespeed = 200;
	// Use this for initialization
	void Start () {
    }
    public void SetText(string s)
    {
        gameObject.GetComponent<Text>().text = s;
    }
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y + Time.deltaTime * movespeed,transform.localPosition.z);

        onTimeDestroy -= Time.deltaTime;
        if (onTimeDestroy < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
