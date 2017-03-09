using UnityEngine;
using System.Collections;

public class Game_Input : MonoBehaviour {

    public delegate void QteInputResult(bool r);
    public bool allowMove = true;
    public Transform trDragon;
    public bool AllowMove
    {
        get { return allowMove; }
        set { allowMove = value; }
    }
    private Transform tr;
    //private Vector3 lastMousePos, mypos;
    //private float speedrate = 1f;
    //private Vector3 posdiffer;
    //private float _agl = 0, _agl0 = 0;
    private Camera cm;
    private Camera sceneCamera;
    private Vector3 touchPos;
    private Vector3 offset;
    private Vector3 screenDragonPos;
    private bool isMove = false;


    private Vector3 screenOffsetPos;
    private Vector3 screenLastFramePos;
    private float vScale;
    private float hScale;
    private Vector2 targetPos;

    private Item Item;
    private float moveSpeed = 1;
    private float moveSpeed_base = 1;
    //private bool qteFlag = false;

    void Awake()
    {

        touchPos = Vector3.zero;
        offset = Vector3.zero;
        //sceneCamera = GameObject.Find("SceneCam").GetComponent<Camera>();
        //cm = GameObject.FindGameObjectWithTag("playercamera").camera;

    }

/*
    void SetControl(GameObject tg, BattleEventArgs e)
    {
        this.allowMove = (bool)e.Arg["value"];
    }
*/

    void OnDestroy()
    {
        //BattleMsgCenter.ControlPauseOrResumeHandler -= this.SetControl;
    }

    void Start()
    {

        tr = transform;
        screenDragonPos = cm.WorldToScreenPoint(tr.position);

        vScale = (GameData.gamePlaneData.GamePlane_Right - GameData.gamePlaneData.GamePlane_Left) / Screen.width;
        hScale = (GameData.gamePlaneData.GamePlane_Top - GameData.gamePlaneData.GamePlane_Bottom) / Screen.height;

        Item = GetComponentInChildren<Item>();
    }

    void StartMove()
    {
        screenOffsetPos = Vector3.zero;
        screenLastFramePos = touchPos;
        offset = touchPos - cm.WorldToScreenPoint(tr.position);
        //Debuger.Log("offset:"+offset);
        isMove = true;
    }
    void ScreenPosMove()
    {
        //screenDragonPos = touchPos - offset;
        screenOffsetPos = touchPos - screenLastFramePos;
    }
    void StopMove()
    {
        screenOffsetPos = Vector3.zero;
        screenLastFramePos = Vector3.zero;
        isMove = false;
    }

    void SetDragonPos()
    {

        Vector3 dragonpos = new Vector3(tr.position.x + screenOffsetPos.x * vScale * moveSpeed, tr.position.y + screenOffsetPos.y * hScale * moveSpeed, 0);
        if (dragonpos.x < GameData.gamePlaneData.GamePlane_Left)
        {
            dragonpos.x = GameData.gamePlaneData.GamePlane_Left;
        }
        else if (dragonpos.x > GameData.gamePlaneData.GamePlane_Right)
        {
            dragonpos.x = GameData.gamePlaneData.GamePlane_Right;
        }

        if (dragonpos.z > GameData.gamePlaneData.GamePlane_Top)
        {
            dragonpos.z = GameData.gamePlaneData.GamePlane_Top;
        }
        else if (dragonpos.z < GameData.gamePlaneData.GamePlane_Bottom)
        {
            dragonpos.z = GameData.gamePlaneData.GamePlane_Bottom;
        }
        //tr.localEulerAngles =  new Vector3(0, 0, screenOffsetPos.x*10 );

        trDragon.rotation = Quaternion.Lerp(trDragon.rotation, Quaternion.Euler(new Vector3(0, Mathf.Clamp(screenOffsetPos.x * -20, -60f, 60f), 0)), Time.deltaTime * 5);

        tr.position = new Vector3(dragonpos.x, dragonpos.y, 0);
        screenLastFramePos = touchPos;
        screenOffsetPos = Vector3.zero;
    }

    void QTEInputCallback(bool result)
    {

    }

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(100, 100, 300, 100), "qte"))
    //    {
    //        StartQte(this.QTEInputCallback);
    //    }
    //}


    public void StartQte(QteInputResult qir)
    {
        //if (qteFlag)
        //    return;
        //else
        //    qteFlag = true;
        AllowMove = false;
        StartCoroutine(this.OnQTE(qir));

    }

    IEnumerator OnQTE(QteInputResult qir)
    {
        Time.timeScale = 0.1f;
        float inputtime = 0.2f;
        float sumtime = 0;
        bool qteinputok = false;
        float inputMaxDis = Screen.height / 5;

        Vector2 touchPos = Vector2.zero;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
                touchPos = Input.GetTouch(0).position;
            else
                touchPos = Vector2.zero;
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButton(0))
                touchPos = Input.mousePosition;
            else
                touchPos = Vector2.zero;
        }
        //MainUI.Instance.QteArrowShow ();//原开界面
        //start ui notice

        while (sumtime < inputtime)
        {
            sumtime += Time.deltaTime;

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        touchPos = Input.GetTouch(0).position;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        if ((Input.GetTouch(0).position.y - touchPos.y) > inputMaxDis)
                        {
                            qteinputok = true;
                            sumtime = inputtime;
                            //MainUI.Instance.QteArrowHide();//原开界面
                            //on qte ok: stop ui notice
                            ////////////////
                        }
                    }
                }
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    touchPos = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {
                    if ((Input.mousePosition.y - touchPos.y) > inputMaxDis)
                    {
                        qteinputok = true;
                        sumtime = inputtime;
                        //MainUI.Instance.QteArrowHide();//原开界面
                        //on qte ok: stop ui notice
                        ////////////////
                    }
                }
            }

            yield return null;
        }



        if (!qteinputok)
        {
            //MainUI.Instance.QteArrowHide();//原开界面
            //on qte fail: stop ui notice
            ////////////////////////////////
            Time.timeScale = 1f;
            AllowMove = true;
            qir(false);
        }
        else
        {
            float moveUpTime = 0.4f;
            float moveDownTime = 0.6f;
            float moveUpSpeed = 150f;
            float moveUpSumTime = 0f;
            float moveUpAccSpeed = 375f;
            float moveDownAccSpeed = 166.7f;
            float frameDeltaPos = 0f;

            Vector3 moveUpTargetPos = cm.transform.position - new Vector3(0, 10, 0);
            Vector3 movetot = (moveUpTargetPos - trDragon.position).normalized;
            Vector3 movetos = (trDragon.position - moveUpTargetPos).normalized;

            Time.timeScale = 0.6f;
            while (moveUpSumTime < moveUpTime)
            {
                moveUpSumTime += Time.deltaTime;
                frameDeltaPos = moveUpSpeed * Time.deltaTime;
                moveUpSpeed -= Time.deltaTime * moveUpAccSpeed;
                trDragon.position += movetot * frameDeltaPos;
                yield return null;
            }

            moveUpSumTime = 0;
            while (moveUpSumTime < moveDownTime)
            {
                moveUpSumTime += Time.deltaTime;
                frameDeltaPos = moveUpSpeed * Time.deltaTime;
                moveUpSpeed += Time.deltaTime * moveDownAccSpeed;
                trDragon.position += movetos * frameDeltaPos;
                yield return null;
            }
            trDragon.localPosition = new Vector3(0, 0, 0);
            Time.timeScale = 1f;
            AllowMove = true;
            qir(true);
        }
        //qteFlag = false;
    }


    public void SetCtrlAllow()
    {
        if (allowMove)
            screenDragonPos = cm.WorldToScreenPoint(tr.position);
        else
            screenDragonPos = Vector3.zero;
    }
    public void SetPlayerMoveSpeed(float sd)
    {
        moveSpeed = this.moveSpeed_base * (1 + sd);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        touchPos = Input.touches[0].position;
                        ScreenPosMove();
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        StopMove();
                    }
                }
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                if (Input.GetMouseButton(0))
                {
                    touchPos = Input.mousePosition;
                    ScreenPosMove();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    StopMove();
                }
            }
        }
        else
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        touchPos = Input.touches[0].position;
                        StartMove();
                    }
                }
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    touchPos = Input.mousePosition;
                    StartMove();
                }
            }
        }


        if (!AllowMove)
            return;
        SetDragonPos();
    }
}

