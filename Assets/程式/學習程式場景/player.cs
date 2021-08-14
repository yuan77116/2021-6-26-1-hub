using UnityEngine;

public class player : MonoBehaviour
{
    #region 課堂練習

    [Header("移動速度"), Range(0, 300)]
    public float speed = 150;
    [Header("跳躍高度"), Range(0, 10)]
    public int playerjump = 2;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("是否在地板上"), Tooltip("碰到地板?")]
    public bool isground = false;
    [Header("檢查地板區域：位移與半徑")]
    public Vector3 groundOffest;
    [Range(0, 2)]
    public float groundRadius = 0.5f;
    [Header("2段跳")]
    private int jump2 = 0;
    [Header("冷卻時間")]
    private float acd = 1.2f;
    /// <summary>
    /// 攻擊計時器
    /// </summary>
    private float timer;
    /// <summary>
    /// 是否攻擊
    /// </summary>
    private bool isatk;

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
        ani = GetComponent<Animator>();
    }
    //不穩定60次
    private void Update()
    {
        GetPlayerHorizontal();
        Jump();
        Atk();
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
    {       /**第一種寫法 自訂重力
            //Vector2 posMove = transform.position + new Vector3(horizontal,-gravity,0) * speed * Time.fixedDeltaTime;
            rig.MovePosition(posMove);**/
        //第二種寫法 物理加速度效果 (移速要增加.跳躍要減少)
        rig.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, rig.velocity.y);
        ani.SetBool("走路", horizontal!=0);
    }
    [Header("負重力"),Range(0.01f,1)]
    public float gravity=0.45f;
    ///<summary>
    ///跳躍
    /// </summary>
    private void Jump()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundOffest, groundRadius,1<<6); //也可用v3 1<<6 使用的圖層 [ <<位移運算子 1<<圖層編號 ]
        if (hit)
        {
            print("碰到的物件 " + hit);
            isground = true;
            jump2 = 0;
        }
        else isground = false;

        if (Input.GetKeyDown(KeyCode.K)&& jump2!=2)
        {
            rig.velocity = Vector2.zero;
            jump2++;
            rig.AddForce(new Vector2(0, playerjump*200));
        }
        ani.SetBool("跳躍", !isground);
    }
    ///<summary>
    ///攻擊
    /// </summary>
    private void Atk()
    {
        if (!isatk && Input.GetKeyDown(KeyCode.J))
        {
            isatk = true;
            ani.SetTrigger("攻擊");
        }
        if (isatk)
        {
            if(timer< acd)
            {
                timer += Time.deltaTime;
                //print("攻擊累加時間 " + timer);
            }
            else
            {
                timer = 0;
                isatk = false;
            }
        }
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
    //繪製圖示事件
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //Gizmos.DrawSphere(transform.position,2); //(中心點，半徑)
        Gizmos.DrawSphere(transform.position + groundOffest, groundRadius);
    }
    #endregion
}
