using UnityEngine;


///<summary>
///
/// </summary>
public class api : MonoBehaviour
{
    //Api 靜態 = 有static
    //Api 動態 = 無static
    //Static Properties 屬性
    //Static Methods 方法

    //private void Start()
    //{
    //    print("隨機值 " + Random.value);
    //    print("無限大 " + Mathf.Infinity);
    //    print("負無限大 " + Mathf.NegativeInfinity);
    //    Cursor.visible = true;
    //    Screen.fullScreen = true;
    //    print(Random.Range(100.009f,300));
    //    float r = Random.Range(1.5f, 7.5f);
    //    print("隨機7.5~1.5 "+r);
    //}
    //[Range(0,100)]
    //public float hp=100;
    //private void Update()
    //{
    //    hp = Mathf.Clamp(hp, 0, 100);
    //    print("血量 " + hp);
    //}

    #region 課堂練習
    //取得
    public float m = 9.999f;
    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(22,22,22);

    private void Start()
    {
        //設定
        Physics2D.gravity = new Vector2(0, -20);
        Time.timeScale = 0.5f;   //暫停/減速0~1系統
        //方法
        print("攝影機數量 = "+ Camera.allCamerasCount);
        print("重力大小 = " + Physics2D.gravity);
        print("圓周率 = " + Mathf.PI);
        //方法
        print("m = " + Mathf.Abs(m));
        float c = Vector3.Distance(a, b);
        print("a.b距離 = " + c);
        //開網頁
        Application.OpenURL("https://unity.com/");
    }

    private void Update()
    {
        print("是否輸入任意鍵 = " + Input.anyKey);
        print("遊戲經過時間 = " + Time.time);
        //方法
        bool space = Input.GetKeyDown("space");
        print("按下space = " + space);
    }
         //Mathf.Round (1.2f)  輸出: 1
         // Mathf.Round(1.6f)  輸出: 2

         //Mathf.Round(1.5f)  輸出: 2
         //Mathf.Round(2.5f)  輸出: 2

         //2. 無條件進位
         //Mathf.Ceil(1.2f)  輸出: 2
         //Mathf.Ceil(1.6f)  輸出: 2

         //3. 無條件捨去
         //Mathf.Floor(1.2f)  輸出: 1
         //Mathf.Floor(1.6f)  輸出: 1

         //4. 絕對值
         //Mathf.Abs(1.2f)  輸出: 1.2
         //Mathf.Abs(-1.6f)  輸出: 1.6
    #endregion

}
