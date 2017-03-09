using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GameData
{

    public static Dictionary<string, string> baseConfig;

    //飞龙部分//
    //飞龙初始//
    public static Dictionary<string, string> dragonInitDataList;
    public static List<string> dragonInitDataListTitel;

    //飞龙升级//
    public static Dictionary<string, string> dragonLevelDataList;
    public static List<string> dragonLevelDataListTitel;

    //飞龙升星//
    public static Dictionary<string, string> dragonStarDataList;
    public static List<string> dragonStarDataListTitel;

    //飞龙升阶//
    public static Dictionary<string, string> dragonQualityDataList;
    public static List<string> dragonQualityDataListTitel;

    //装备 相关数据表
    public static Dictionary<string, string> equipDataList;
    public static List<string> equipDataTitel;

    public static Dictionary<string, string> equipDataLvList;
    public static List<string> equipDataLvTitel;

    public static Dictionary<string, string> equipcompoundList;
    public static List<string> equipcompoundTitle;

    public static Dictionary<string, string> equipgroupDataList;
    public static List<string> equipgroupDataTitle;

    public static Dictionary<string, string> equipnatureDataList;
    public static List<string> equipnatureDataTitle;

    public static Dictionary<string, string> equipstrengthenInfoList;
    public static List<string> equipstrengthenInfoTitle;
    //buff
    public static Dictionary<string, string> buffDataList;
    public static List<string> buffDataTitle;

    //battle
    public static Dictionary<string, string> monsterTurnDataList;
    public static Dictionary<string, string> monsterTeamDataList;
    public static List<string> monsterTurnDataTitle;
    public static List<string> monsterTeamDataTitle;
    //public static Dictionary<string, string> equipData


    //enemy
    public static Dictionary<string, string> enemyDataList;
    public static List<string> enemyDataTitel;

    public static Dictionary<string, string> enemySkillDataList;
    public static List<string> enemySkillDataTitle;

    public static Dictionary<string, string> dropPackageDataList;
    public static List<string> dropPackageDataTitle;

    public static Dictionary<string, string> enemyLvDataList;
    public static List<string> enemyLvDataTitel;

    public static Dictionary<string, string> enemyDropDataList;
    public static List<string> enemyDropDataTitle;

    //boss

    public static Dictionary<string, string> bossDataList;
    public static List<string> bossDataTitel;

    public static Dictionary<string, string> bossLvDataList;
    public static List<string> bossLvDataTitel;

    public static Dictionary<string, string> battleCalDataList;
    public static List<string> battleCalDataTitle;
    //
    public static Dictionary<string, string> storyDataList;
    public static List<string> storyDataTitle;

    public static Dictionary<string, string> missionDataList;
    public static List<string> missionDataTitle;

    public static Dictionary<string, string> itemPackageDataList;
    public static List<string> itemPackageDataTitle;

    public static Dictionary<string, string> itemsDataList;
    public static List<string> itemsDataTitle;

    public static Dictionary<string, string> coinDataList;
    public static List<string> coinDataTitle;

    public static Dictionary<string, string> dropStarDataList;
    public static List<string> dropStarDataTitle;

    public static Dictionary<string, string> gameStoreDataList;
    public static List<string> gameStoreDataTitle;

    public static Dictionary<string, string> rechargeStoreDataList;
    public static List<string> rechargeStoreDataTitle;

    public static Dictionary<string, string> vipDataList;
    public static List<string> vipDataTitle;

    public static Dictionary<string, string> skillDataList;
    public static List<string> skillDataTitle;

    public static Dictionary<string, string> sectionDataList;
    public static List<string> sectionDataTitle;

    //关卡
    public static Dictionary<string, string> combatDataList;
    public static List<string> combatDataTitle;

    #region role
    //角色
    public static Dictionary<string, string> roleProffessionDataList;
    public static List<string> roleProffessionDataTitle;

    public static Dictionary<string, string> roleUpgradeDataList;
    public static List<string> roleUpgradeDataTitle;

    public static Dictionary<string, string> roleSkillDataList;
    public static List<string> roleSkillDataTitle;


    #endregion

    //中文描述字典
    public static Dictionary<string, string> textInfoList;
    public static List<string> textInfoListTitle;

    public static Dictionary<string, string> mallDataList;
    public static List<string> mallDataTitle;

    public static Dictionary<string, string> activityDataList;
    public static List<string> activityDataTitle;
    //GamePlane Define
    public static GamePlaneData gamePlaneData;

    public static List<MallDataClass> mall;



    public static float forceLow;
    public static float forceEqual;
    public static float forceStrongthan;
    public static string[] sensitiveWord;
    //
    //public static string socketAddress;
    //public static int socketPort;


    static GameData()
    {
        gamePlaneData = new GamePlaneData();

    }

    public static void CreateClientDataList()
    {
       
    }
    public static string[] fontColor;
    /// <summary>
    /// Assetbundle下载地址
    /// </summary>
    public static string AssetbundleUrl { get; set; }

    /// <summary>
    /// socket地址
    /// </summary>
    public static string SocketAddress { get; set; }
    /// <summary>
    /// socket端口号
    /// </summary>
    public static int SocketPort { get; set; }
    /// <summary>
    /// 客户端版本号
    /// </summary>
    public static string Version { get { return _version; } }
    public static GameColor Color = new GameColor();
    public static string NewsNoticeAddress;
    public static string _version = "1.01";
    public static int platform;
    public static int channel;
    public static int os;

    public static string GetItemBorderSpriteName(int quality)
    {
        switch (quality)
        {
            case -1: return "equipment_bg_lock";
            case 1: return "green_border_1";
            case 2: return "blue_border_1";
            case 3: return "purple_border_1";
            default: return "white_border_1";
        }
    }


    #region LotteryConfig
    public static int lotteryOncePay;
    public static int lotteryTenPay;
    public static int lotteryOnceTime;
    public static int lotteryTenTime;
    #endregion

    #region BagConfig
    public static int bagExtendPay;
    public static int bagExtendCount;
    public static int bagCapacityMax;
    #endregion
#if UNITY_IPHONE
    //private static IphoneData _iphonedata;
    //public static IphoneData GetIphoneData()
    //{
    //    if (_iphonedata == null)
    //    {
    //        _iphonedata = new IphoneData() { mac=CommonDataClass.GetIPHONEMAC(), ip=CommonDataClass.GetClientIp(), idfa=CommonDataClass.GetIPHONEIDFA()   };
    //    }
    //    return _iphonedata;
    //}
#endif
    public static string deviceIDkey { get; set; }
}
public class GameColor
{
    public Color Blue = new Color(0.34f, 0.43f, 0.76f, 1f);
    public Color Purple = new Color(0.58f, 0.21f, 0.86f, 1f);
    public Color Black = new Color(0f, 0f, 0f, 1f);
    public Color White = new Color(1f, 1f, 1f, 1f);
}