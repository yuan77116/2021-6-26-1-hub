using UnityEngine;

public class player : MonoBehaviour
{
    #region 課堂練習

    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int playerjump = 100;
    [Header("血量"),Range(0,200)]
    public float hp = 100;
    [Header("是否在地板上"),Tooltip("碰到地板?")]
    public bool isground = false;

    private  AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion
    #region 方法練習
    //欄位
    [Range(-1, 1)]
    public float 速度=0;
    public bool 跳=false;
    //事件
    private void Start()
    {
        Move(0);
        Jump();
        Atk();
        Hurt(0);
        Dead();
        ErtProp("肉");
    }
    //方法

    ///<summary>
    ///移動
    /// </summary>
    /// ///<param name="x軸方向">角色移動方向</param>
    private void Move(float x軸方向)
    {
        
    }
    ///<summary>
    ///跳躍
    /// </summary>
    private void Jump()
    {

    }
    ///<summary>
    ///攻擊
    /// </summary>
    private void Atk()
    {
        
    }
    ///<summary>
    ///受傷
    /// </summary>
    /// ///<param name="造成的傷害">角色受了多少傷害</param>
    public void Hurt(float 造成的傷害)
    {
        
    }
    ///<summary>
    ///死亡
    /// </summary>
    private void Dead()
    {
        
    }
    ///<summary>
    ///撿起的道具名
    /// </summary>
    /// ///<param name="道具名稱">撿起的道具名稱</param>
    private void ErtProp(string 道具名稱)
    {
        print("吃到：" + 道具名稱);
    }

    #endregion
}
