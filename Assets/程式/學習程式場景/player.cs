using UnityEngine;

public class player : MonoBehaviour
{
    #region 課堂練習

    [Header("移動速度"), Range(0, 100)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 30)]
    public int playerjump = 10;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("是否在地板上"), Tooltip("碰到地板?")]
    public bool isground = false;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion
    #region 方法練習
    //欄位
    //public float 速度=0;
    //public bool 跳=false;
    //事件
    private void Start()
    {
        //Move(0);
        //Jump();
        //Atk();
        //Hurt(0);
        //Dead();
        //ErtProp("肉");
        rig = GetComponent<Rigidbody2D>();
    }
    //不穩定60次
    private void Update()
    {
        GetPlayerHorizontal();
        Jump();
    }
    //穩定50次
    private void FixedUpdate()
    {
        Move(hValue);
    }

    //方法

    ///<summary>
    ///x方向
    /// </summary>
    private float hValue;
    /// ///<param name="x軸方向">角色方向</param>
    private void GetPlayerHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");
        //print("玩家水平值 "+hValue);
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    ///<summary>
    ///移動
    /// </summary>
    /// ///<param name="horizontal">角色移動方向</param>
    private void Move(float horizontal)
    {
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity,0) * speed * Time.fixedDeltaTime;
        rig.MovePosition(posMove);
    }
    [Header("負重力"),Range(0.01f,1)]
    public float gravity=0.45f;
    ///<summary>
    ///跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            rig.AddForce(new Vector2(0, playerjump*200));
        }
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
