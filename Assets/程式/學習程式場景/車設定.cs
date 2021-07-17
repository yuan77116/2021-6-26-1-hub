//using System.Collections;
//using System.Collections.Generic;
using UnityEngine; //引用 unity 引擎 engine 命名空間

public class 車設定 : MonoBehaviour
{
    //單行註解2021/7/17

    #region 註解介紹
    //類別class
    //欄位field
    //功能method

    //整數 int  ex：1
    //浮點數 float ex：1.1
    //字串 string ex："我"
    //布林值 bool ex：true  or  false

    /*  多行註解
     1122334455
     6677  */

    //欄位屬性-標題:[Header(字串介紹)]
    //private 私人(預設不可觀)
    //public  公開用(可觀)

    //數值以畫面旁的屬性面板為主

    //中文命名不建議，有翻譯耗能問題
    #endregion
    #region 車設定
    [Header("重量")]
    [Tooltip("數值限制1~5000")]
    [Range(1,5000)]
    public float weight = 10 * 50 + 0.2f;
    [Header("馬力cc")]
    public int Horsepowe_cc = 550;
    [Header("品牌")]
    public string Brand = "普通南瓜";
    [Header("有無天窗")]
    public bool Skylight = false;
    [Header("顏色")]
    public string colour = "黃色";
    //public Color red=Color.red;
    public Color color1 = new Color(10,255,125,200);
    #endregion
    #region 座標
    public Vector2 v20;//(0,0)
    public Vector2 v21 = Vector2.zero;//(0,0)
    public Vector2 v22 = Vector2.right; //(1,0)
    public Vector2 v23 = Vector2.up; //(0,1)
    public Vector2 v24 = -Vector2.up;//(0,-1)
    public Vector2 v25 = new Vector2(-99,100);
    #endregion
    #region 按鍵類型
    public KeyCode kc;
    public KeyCode forword=KeyCode.D;
    public KeyCode attatk=KeyCode.Mouse0;
    public KeyCode jump=KeyCode.Mouse2;
    public KeyCode dodge=KeyCode.Mouse1;
    #endregion
    #region 物件
    public GameObject camera;
    public Transform 位置;
    public SpriteRenderer 圖;
    #endregion
}
