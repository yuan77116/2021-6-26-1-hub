using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    public UnityEvent 死亡事件;
    #region 課堂練習
    [Header("攻擊力"), Range(0, 300)]
    public float 攻擊力 = 10;
    [Header("移動速度"), Range(0, 300)]
    public float speed = 150;
    [Header("跳躍高度"), Range(0, 10)]
    public int playerjump = 2;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    private float 最大hp;
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
    private Cameraa1a2 cameraa;

    private Text 血量hp;
    private Image 圖片hp;
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
        aud = GetComponent<AudioSource>();
        血量hp = GameObject.Find("文字血量").GetComponent<Text>();
        圖片hp = GameObject.Find("血條").GetComponent<Image>();
        最大hp = hp;
        cameraa = GameObject.Find("Main Camera").GetComponent<Cameraa1a2>();
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
        ani.SetBool("走路", horizontal != 0);
    }
    [Header("負重力"), Range(0.01f, 1)]
    public float gravity = 0.45f;
    ///<summary>
    ///跳躍
    /// </summary>
    private void Jump()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundOffest, groundRadius, 1 << 6); //也可用v3 1<<6 使用的圖層 [ <<位移運算子 1<<圖層編號 ]
        if (hit)
        {
            print("碰到的物件 " + hit);
            isground = true;
            jump2 = 0;
        }
        else isground = false;

        if (Input.GetKeyDown(KeyCode.K) && jump2 != 2)
        {
            rig.velocity = Vector2.zero;
            jump2++;
            rig.AddForce(new Vector2(0, playerjump * 200));
            aud.PlayOneShot(音效跳躍, Random.Range(0.7f, 1.1f)); //聲音大小
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

            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * v2攻擊區域.x + transform.up * v2攻擊區域.y, v3尺寸, 0, 1 << 8);
            if (hit)
            {
                print(hit.name);
                hit.GetComponent<怪物控制>().受傷(攻擊力);
                StartCoroutine(cameraa.晃動());
            }
        }
        if (isatk)
        {
            if (timer < acd)
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
        hp -= 造成的傷害;
        ani.SetTrigger("受傷");
        if (hp <= 0)
        {
            Dead();
        }
        血量hp.text = "血量 " + hp;
        圖片hp.fillAmount = (hp / 最大hp);
    }
    ///<summary>
    ///死亡
    /// </summary>
    private void Dead()
    {
        hp = 0;
        ani.SetBool("死亡", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.velocity = Vector2.zero;
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
        enabled = false;
        死亡事件.Invoke();
    }
    ///<summary>
    ///撿起的道具名
    /// </summary>
    /// ///<param name="道具名稱">撿起的道具名稱</param>
    private void ErtProp(string 道具名稱)
    {
        switch (道具名稱)
        {
            case "掉落道具":
                print("吃到：" + 道具名稱);
                Destroy(hit掉落物,0.2f);
                hp = Mathf.Clamp(hp, 0, 最大hp);
                hp += 10;
                血量hp.text = "血量 " + hp;
                圖片hp.fillAmount = (hp / 最大hp);
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ErtProp(collision.gameObject.tag);
        if (collision.transform.tag == "掉落道具")
        {
            hit掉落物 = collision.gameObject;
        }

    }
    private GameObject hit掉落物;
    //繪製圖示事件
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //Gizmos.DrawSphere(transform.position,2); //(中心點，半徑)
        Gizmos.DrawSphere(transform.position + groundOffest, groundRadius);
        Gizmos.color = new Color(1, 0.3f, 0.1f, 0.3f);
        Gizmos.DrawCube(transform.position + transform.right * v2攻擊區域.x + transform.up * v2攻擊區域.y, v3尺寸);
    }
    #endregion
    [Header("攻擊區域")]
    public Vector2 v2攻擊區域;
    public Vector3 v3尺寸;
    public AudioClip 音效跳躍;
}
