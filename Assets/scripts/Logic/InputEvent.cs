using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrag(PointerEventData data)
    {

    }


    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("on up");
    }


    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("on down");
    }

    void OnDisable()
    {
    }
}
