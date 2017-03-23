using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFace : MonoBehaviour {

    public GameObject go;
    public Transform node1;
    public Transform node2;

    public ScrollRect scrollRect;
    public RectTransform rectContent;

    // Use this for initialization
    void Start () {
        CreateFace(node1,1);
        CreateFace(node2,10);
    }
    void CreateFace(Transform tr,int ex)
    {
        GameObject temp;
        for (int i = 0; i < 20; i++)
        {
            temp = (GameObject)Instantiate(go);
            temp.transform.SetParent(tr);
            temp.transform.localScale = Vector3.one;
            temp.transform.localPosition = Vector3.down * 90 * i;
            temp.GetComponent<UI_ScoreBar>().SetScoreInfo(1, ex, 1, "yangxiao", "1234");
        }
    }
    public void ChanageScoreBoare(bool isleft)
    {
        if (node1.localPosition.x == 0)
        {
            node1.localPosition = new Vector3(600, 0, 0);
        }
        else
        {
            node1.localPosition = new Vector3(0, 0, 0);
        }
        if (node2.localPosition.x == 0)
        {
            node2.localPosition = new Vector3(600, 0, 0);
        }
        else
        {
            node2.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void CenterOnItem(RectTransform target)
    {

        RectTransform contentTransform = gameObject.GetComponent<RectTransform>();
        RectTransform viewPointTransform = gameObject.GetComponent<RectTransform>(); ;

        // Item is here
        var itemCenterPositionInScroll = GetWorldPointInWidget(scrollRect.GetComponent<RectTransform>(), GetWidgetWorldPoint(target));
        Debug.Log("Item Anchor Pos In Scroll: " + itemCenterPositionInScroll);
        // But must be here
        var targetPositionInScroll = GetWorldPointInWidget(scrollRect.GetComponent<RectTransform>(), GetWidgetWorldPoint(viewPointTransform));
        Debug.Log("Target Anchor Pos In Scroll: " + targetPositionInScroll);
        // So it has to move this distance
        var difference = targetPositionInScroll - itemCenterPositionInScroll;
        difference.z = 0f;

        var newNormalizedPosition = new Vector2(difference.x / (contentTransform.rect.width - viewPointTransform.rect.width),
            difference.y / (contentTransform.rect.height - viewPointTransform.rect.height));

        newNormalizedPosition = scrollRect.normalizedPosition - newNormalizedPosition;

        newNormalizedPosition.x = Mathf.Clamp01(newNormalizedPosition.x);
        newNormalizedPosition.y = Mathf.Clamp01(newNormalizedPosition.y);

        //DOTween.To(() => scrollRect.normalizedPosition, x => scrollRect.normalizedPosition = x, newNormalizedPosition, 3);
    }

    Vector3 GetWidgetWorldPoint(RectTransform target)
    {
        //pivot position + item size has to be included
        var pivotOffset = new Vector3(
            (0.5f - target.pivot.x) * target.rect.size.x,
            (0.5f - target.pivot.y) * target.rect.size.y,
            0f);
        var localPosition = target.localPosition + pivotOffset;
        return target.parent.TransformPoint(localPosition);
    }

    Vector3 GetWorldPointInWidget(RectTransform target, Vector3 worldPoint)
    {
        return target.InverseTransformPoint(worldPoint);
    }
    // Update is called once per frame
    void Update () {
	}
}
