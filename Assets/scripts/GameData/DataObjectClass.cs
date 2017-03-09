using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Item
{
    public Item()
    {
    }
}

public enum CalcType
{
    Combat = 1,
    Battle
}
public enum StackType
{
    NoStack = 1,
    TimeStack,
    floorStack
}

public class MallDataClass
{
    public string id;
    public int type;
    public int orderMall;
    public string icon;
    public string name;
    public string describe;
    public bool isnew;
    public bool discount;
    public int viplv;
    public int costbefore;
    public int cost;
    public MallDataClass(string mid)
    {
        this.id = mid;
        Dictionary<string, string> temp = new Dictionary<string, string>();
        string[] einfo = GameData.mallDataList[mid].Split(',');
        for (int i = 0; i < GameData.mallDataTitle.Count; i++)
            temp.Add(GameData.mallDataTitle[i], einfo[i]);
        this.type = int.Parse(temp["type"]);
        this.orderMall = int.Parse(temp["orderMall"]);
        this.icon = temp["icon"];
        this.name = temp["name"];
        this.describe = temp["describe"];
        this.isnew = bool.Parse(temp["isnew"]);
        this.discount = bool.Parse(temp["discount"]);
        this.viplv = int.Parse(temp["VIP"]);
        this.costbefore = int.Parse(temp["costbefore"]);
        this.cost = int.Parse(temp["cost"]);

    }
    public static List<MallDataClass> GetMallAll()
    {
        List<MallDataClass> list = new List<MallDataClass>();
        foreach (var d in GameData.mallDataList)
        {
            if (d.Key != "id")
            {
                list.Add(new MallDataClass(d.Key));
            }
        }
        return list;
    }

}

public class StoryDataClass
{
    public string id;
    public string lv_id;
    public StoryStage stage;
    public List<StoryInfo> storyList = new List<StoryInfo>();

    public StoryDataClass(string sid)
    {
        this.id = sid;
        Dictionary<string, string> temp = new Dictionary<string, string>();
        string[] einfo = GameData.storyDataList[sid].Split(',');
        for (int i = 0; i < GameData.storyDataTitle.Count; i++)
            temp.Add(GameData.storyDataTitle[i], einfo[i]);

        lv_id = temp["lv_id"];
        stage = (StoryStage)int.Parse(temp["stage"]);
        string[] storyinfos = temp["info"].Split('|');

        for (int i = 0; i < storyinfos.Length; i++)
        {
            string[] infos = storyinfos[i].Split(';');
            StoryInfo si = new StoryInfo() { Name = infos[1], Icon = infos[2], Position = (StoryPosition)int.Parse(infos[0]), Info = infos[3] };
            storyList.Add(si);
        }
    }

}

public class StoryBase
{
    public string Icon { get; set; }
    public string Info { get; set; }
}

public class StoryInfo : StoryBase
{
    public string Name { get; set; }
    public StoryPosition Position { get; set; }

}

public class SkillDataClass
{
    public string id;
    public string name;
    public string describe;
    public float coldtime;
    public float damage;


    public SkillDataClass(string sid)
    {
        this.id = sid;
        Dictionary<string, string> temp = new Dictionary<string, string>();
        string[] einfo = GameData.skillDataList[sid].Split(',');


        for (int i = 0; i < GameData.skillDataTitle.Count; i++)
        {
            temp.Add(GameData.skillDataTitle[i], einfo[i]);
        }

        name = temp["name"];
        describe = temp["describe"];
        coldtime = float.Parse(temp["skillcd"]);
        damage = float.Parse(temp["skilldamage"]);

    }

}

public class costClass
{
    public CostItemType type { get; set; }
    public int id { get; set; }
    public int count { get; set; }
    public costClass()
    {

    }

    public static List<costClass> GetList(string str)
    {
        List<costClass> list = new List<costClass>();
        if (str != "0")
        {
            string[] costs = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < costs.Length; i++)
            {
                string[] s = costs[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                costClass cost = new costClass();
                cost.type = (CostItemType)int.Parse(s[0]);
                cost.id = int.Parse(s[1]);
                cost.count = int.Parse(s[2]);
                list.Add(cost);
            }
        }
        return list;
    }

    public enum CostItemType
    {
        Coin = 1,
        StuffItem,
        NormalItem,
        BattleItem,
        Equipment = 5
    }
}

public class ItemPackageClass
{
    private string _id;

    public string Id
    {
        get { return _id; }
    }
    public string[] Icon { get; set; }

    public string[] nums { get; set; }
    public ItemPackageClass(string pid)
    {
        this._id = pid;
        Dictionary<string, string> temp = new Dictionary<string, string>();
        string[] einfo = GameData.itemPackageDataList[pid].Split(',');
        for (int i = 0; i < GameData.itemPackageDataTitle.Count; i++)
            temp.Add(GameData.itemPackageDataTitle[i], einfo[i]);
        this.Icon = temp["icon"].Split(';');
        this.nums = temp["num"].Split(';');
    }
}

public class EmailClass
{
    private int _id;

    public int Id
    {
        get { return _id; }
    }
    private int _emailType;

    public int EmailType
    {
        get { return _emailType; }
        set { _emailType = value; }
    }

    private string _title;

    public string Title
    {
        get { return _title; }
    }

    private string _emailFrom;

    public string EmailFrom
    {
        get { return _emailFrom; }
        set { _emailFrom = value; }
    }

    private string[] _info;

    public string[] Info
    {
        get { return _info; }
        set { _info = value; }
    }

    private string _summary;

    public string Summary
    {
        get { return _summary; }
        set { _summary = value; }
    }



    private string _icon;

    public string Icon
    {
        get { return _icon; }
    }

    private bool _beRead;

    public bool BeRead
    {
        get { return _beRead; }
        set { _beRead = value; }
    }



    public EmailClass(int eid, string title, string summary, string icon)
    {
        this._id = eid;
        this._title = title;
        this._icon = icon;
        this._summary = summary;
    }
}
public class DropStarClass
{
    public string id;
    public float time;

    public float percent;
    public int minCount;
    public int maxCount;

    public float nextPercent;
    public string nextId;
    public float radius;

    public DropStarClass(string did)
    {
        this.id = did;
        Dictionary<string, string> temp = new Dictionary<string, string>();
        string[] einfo = GameData.dropStarDataList[did].Split(',');
        for (int i = 0; i < GameData.dropStarDataTitle.Count; i++)
            temp.Add(GameData.dropStarDataTitle[i], einfo[i]);

        time = float.Parse(temp["time"]);
        percent = float.Parse(temp["percent"]);
        minCount = int.Parse(temp["mindrop"]);
        maxCount = int.Parse(temp["maxdrop"]);
        nextPercent = float.Parse(temp["nextpercent"]);
        nextId = temp["nextdrop"];
        radius = float.Parse(temp["radius"]);

    }
}
public class VIPDataClass
{
    /// <summary>
    /// 等级
    /// </summary>
    public int lv;


    /// <summary>
    /// 是否可以扫荡
    /// </summary>
    public bool canWipe;
    /// <summary>
    /// 扫荡次数
    /// </summary>
    public int wipeTimes;
    /// <summary>
    /// 保险冷却
    /// </summary>
    public int coldTime;

    public float skillcoldtime;
    /// <summary>
    /// 最大体力
    /// </summary>
    public int maxEnergy;
    /// <summary>
    /// 复活次数
    /// </summary>
    public int revive;
    /// <summary>
    /// 魔钻换金币次数
    /// </summary>
    public int buyGoldTime;
    /// <summary>
    /// 挑战模式次数
    /// </summary>
    public int challengeTime;
    /// <summary>
    /// 闯关次数
    /// </summary>
    public int Checkpoints;
    /// <summary>
    /// 买体力次数
    /// </summary>
    public int buyEnergyTime;

    public string describe;

    /// <summary>
    /// 充值总值
    /// </summary>
    public int exp;

    /// <summary>
    /// 升级所需充值金额
    /// </summary>
    public int money;

    public string icon;

    public string[] buffs;

    public VIPDataClass(int elv)
    {
        this.lv = elv;
        Dictionary<string, string> temp = new Dictionary<string, string>();
        if (!GameData.vipDataList.ContainsKey(lv.ToString()))
        {
            this.lv = 4;
        }

        string[] einfo = GameData.vipDataList[lv.ToString()].Split(',');
        for (int i = 0; i < GameData.vipDataTitle.Count; i++)
        {
            temp.Add(GameData.vipDataTitle[i], einfo[i]);
        }
        canWipe = Convert.ToBoolean(int.Parse(temp["canwipe"]));
        wipeTimes = int.Parse(temp["wipetimes"]);
        coldTime = int.Parse(temp["coldtime"]);
        skillcoldtime = float.Parse(temp["skillcoldtime"]);
        maxEnergy = int.Parse(temp["maxEnemy"]);
        revive = int.Parse(temp["revive"]);
        buyGoldTime = 0;//int.Parse(temp["buygoldtime"]);
        challengeTime = int.Parse(temp["challengetime"]);
        Checkpoints = int.Parse(temp["Checkpoints"]);
        buyEnergyTime = int.Parse(temp["buyEnemyTime"]);
        describe = temp["describe"];
        money = int.Parse(temp["money"]);
        buffs = temp["buff"].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        icon = temp["icon"];
    }


    public static List<VIPDataClass> GetVipDescribeAll()
    {
        List<VIPDataClass> slist = new List<VIPDataClass>();
        for (int i = 0; i > -1; i++)
        {
            if (GameData.vipDataList.ContainsKey(i.ToString()))
            {
                slist.Add(new VIPDataClass(i));
            }
            else
            {
                break;
            }
        }
        return slist;
    }
}


public class GamePlaneData
{
    public float GamePlane_Top;
    public float GamePlane_Left;
    public float GamePlane_Bottom;
    public float GamePlane_Right;

    public Vector3 cameraPos;
    public int cameraAngel;


    public GamePlaneData()
    {
        //3:4 = 0.75;
        //9:16 = 0.5625
        //2:3 = 0.667

        float p = Screen.width * 1.0f / Screen.height;
        if (p > 0.74f && p < 0.76f)
        {
            cameraPos = new Vector3(0, 0, 0);
            GamePlane_Top = 27;
            GamePlane_Left = -10;
            GamePlane_Bottom = -7;
            GamePlane_Right = 10;
            cameraAngel = 32;
        }
        else if (p > 0.65f && p < 0.67f)
        {
            cameraPos = new Vector3(0, -5f, 0);
            GamePlane_Top = 27f;
            GamePlane_Left = -10;
            GamePlane_Bottom = -6f;
            GamePlane_Right = 10;
            cameraAngel = 36;
        }
        else if (p > 0.55f && p < 0.57f)
        {
            cameraPos = new Vector3(0, -8f, 0);
            GamePlane_Top = 27;
            GamePlane_Left = -10;
            GamePlane_Bottom = -6;
            GamePlane_Right = 10;
            cameraAngel = 40;
        }
        else
        {
            cameraPos = new Vector3(0, -8f, 0);
            GamePlane_Top = 27;
            GamePlane_Left = -10;
            GamePlane_Bottom = -5;
            GamePlane_Right = 10;
            cameraAngel = 40;
        }
    }
}



#region Enum------SoulPostion, ItemType, AttributeType

public enum SoulPostion
{
    Left = 0,
    Middle,
    Right
}

public enum ItemType
{
    Treasure,
    TreasureKey,
    EquipStuff,
    DragonStuff,
    DragonItem,
    BattleItem,
    Other
}



public enum StoryPosition
{
    Top = 1,
    Bottom
}

public enum StoryStage
{
    Start = 1,
    BossBefore,
    End,
    NewbieGuide
}



public enum EquipmentPartName
{
    Head = 1,
    Cloth = 2,
    Hands = 3,
    Belt = 4,
    Trousers = 5,
    Shoes = 6,
    Other
}

public enum BorderType
{
    /// <summary>
    /// 完整
    /// </summary>
    Complete,
    /// <summary>
    /// 碎片
    /// </summary>
    Stuff
}

/// <summary>
///RMB充值=1
///无尽模式战前购买=2
///魔钻换金币=3
///魔钻买体力=4
///抽奖=5
///闯关次数=6
///闯关扫荡=7
/// </summary>
public enum StoreType
{
    Diamond = 1,
    Item,
    Gold,
    Energy,
    Roll,
    BattleCount,
    BattleWipe,
    Buff
}
public enum FontColor
{
    White,
    Green,
    Blue,
    Purple,
    Light,
    Deep,
    Dark
}
public enum CharacterAttributeType
{
    Atk,
    Def,
    Hp,
    Hit,
    HitDamage,
    HitDef
}

public enum CoinType
{ 
    Gold=1,
    Diamond=2,
    Vitality=3,
    DragonSoul=4,
    Experience=5,
    Smelt=6
}
#endregion

