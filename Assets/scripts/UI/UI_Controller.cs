using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {

    public GameObject[] allFace;
    public GameObject sceneMainboard;
    public GameObject sceneSearchItem;
    public GameObject sceneScore;
    public GameObject sceneFireUp_MRK;


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
    public void ChanageUIFace_LoadScene()
    {
        HideAllScene();
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
    public void StartGame()
    {
        ChanageUIFace_LoadScene();
    }
}
