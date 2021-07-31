using UnityEngine;

public class apinostatic : MonoBehaviour
{
    //非靜態需要定義欄位，欄位而不能空值。
    public Transform tA = null;
    public Camera 攝影機 = null;
    public Transform tB = null;
    public Light light = null;
    #region 課堂
    public Camera 攝影機深度 = null; 
    public SpriteRenderer 圖片1 = null;
    public SpriteRenderer 圖片2 = null;
    public SpriteRenderer 圖片3 = null;
    public Rigidbody2D rig;
    #endregion
    private void Start()
    {
        print("取得座標 " + tA);
        print("背景顏色 " + 攝影機.backgroundColor);
        //攝影機.backgroundColor = new Color(0,0.5f,0.6f);
        tB.transform.Translate(1, 0, 0);
        light.Reset();

        #region 課堂
        print("攝影機深度 " + 攝影機深度.depth);
        print("圖片1顏色 " + 圖片1.color);
        //攝影機深度.backgroundColor = new Color(Random.Range(0,255), Random.Range(0,255), Random.Range(0,255));
        攝影機深度.backgroundColor = Random.ColorHSV();
        圖片1.flipY=true;
        #endregion
    }
    private void Update()
    {
        #region 課堂
        圖片2.transform.Rotate(0, 0, 1);
        rig.AddForce(new Vector2(0, 10));
        #endregion
    }
}
