using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {

    public static UI_Controller instance;
    public GameObject[] allFace;
    public GameObject sceneMainboard;
    public GameObject sceneSearchItem;
    public GameObject sceneScore;
    public GameObject sceneFireUp_MRK;

    void Awake()
    {
        instance = this;
    }
    private void HideAllScene()
    {
        for (int i = 0; i < allFace.Length; i++)
        {
            if (allFace[i] != null)
            {
                allFace[i].SetActive(false);
            }
        }
    }
    public void ChanageUIFace_MainBoard()
    {
        HideAllScene();
        sceneMainboard.SetActive(true);
    }
    public void ChanageUIFace_LoadScene()
    {
        HideAllScene();
        sceneMainboard.SetActive(true);
    }
    public void ChanageUIFace_SearchItem()
    {
        HideAllScene();
        sceneSearchItem.SetActive(true);
    }
    public void ChanageUIFace_GameScene()
    {
        HideAllScene();

    }
    public void ChanageUIFace_Score()
    {
        HideAllScene();
        sceneScore.SetActive(true);
    }
    public void UIReset()
    {
        ChanageUIFace_MainBoard();
    }
}
