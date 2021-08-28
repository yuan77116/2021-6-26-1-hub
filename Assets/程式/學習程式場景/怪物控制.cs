using UnityEngine;
using System.Linq;

public class 怪物控制 : MonoBehaviour
{
    [Header("基本能力")]
    [Range(50,5000)]
    public float hp;
    [Range(5, 1000)]
    public float atk;
    [Range(1, 500)]
    public float speed;
    [SerializeField]
    protected StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;
    protected player playerh;
    protected Collider2D hit;

    public Vector2 v2idle = new Vector2(1, 5);
    public Vector2 v2walk = new Vector2(3, 6);
    [Header("檢查地板")]
    public Vector2 checkfoor = new Vector2(1, -0.8f);
    public float checkfoorint=0.3f;

    private float timeidle;
    private float timeridle;
    private float timewalk;
    private float timerwalk;
    private float cdatk=1.2f;
    [Header("攻擊間隔，自訂攻擊數量")]
    public float[] atkdelay;
    [Header("攻擊完成回復")]
    public float 攻擊回復動作=1;
    //[Header("第二次攻擊間隔")]
    //public float[] atkdelay2;
    private float timeratk;

    //public KeyCode key;
    public enum StateEnemy
    {
        idle,walk,atkkack,dead
    }
    //-----------------------------------------------------
    private void Start() //初始值設定
    {
        timeidle = Random.Range(v2idle.x, v2idle.y);
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        playerh = GameObject.Find("主角").GetComponent<player>();
    }
    protected virtual void Update()
    {
        檢查狀態();
        檢查地板();
    }
    private void FixedUpdate()
    {
        fixwilk();
    }
    //-----------------------------------------------------
    private void 檢查狀態()
    {
        switch (state)
        {
            case StateEnemy.idle:
                idle();
                break;
            case StateEnemy.walk:
                walk();
                break;
            case StateEnemy.atkkack:
                攻擊狀態();
                break;
            case StateEnemy.dead:

                break;
            //--------
            default:
                print("狀態不明");
                break;
        }
    }
    private void 攻擊狀態()
    {
        if (timeratk < cdatk)
        {
            timeratk += Time.deltaTime;
            ani.SetBool("走路",false);
        }
        else
        {
            不同的攻擊();
        }
    }
    protected virtual void 不同的攻擊()
    {
        timeratk = 0;
        ani.SetTrigger("攻擊");
        print("攻擊");
    }
    private void idle()
    {
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
        if (timeridle < timeidle)
        {
            timeridle += Time.deltaTime;
            rig.velocity = Vector2.zero; //消除滑行
            print("等待中");
            ani.SetBool("走路", false);
        }
        else
        {
            timeridle = 0;
            state = StateEnemy.walk; //前往狀態
            timewalk = Random.Range(v2walk.x, v2walk.y);
            隨機方向();
        }
    }
    private void walk()
    {
        rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (timerwalk < timewalk)
        {
            timerwalk += Time.deltaTime;
            print("走路中");
            ani.SetBool("走路", true);
        }
        else
        {
            timerwalk = 0;
            state = StateEnemy.idle;
            timeidle = Random.Range(v2idle.x, v2idle.y);
        }
    }
    private void fixwilk()
    {
        if(state== StateEnemy.walk)
        {
            rig.velocity = transform.right * speed * Time.fixedDeltaTime + Vector3.up * rig.velocity.y;
        }
        if (state == StateEnemy.idle)
        {
            rig.velocity =  Vector3.up * rig.velocity.y;
        }
    }
    private void 隨機方向()
    {
        int rand = Random.Range(0,2); //= 0 or 1 !=2
        if (rand == 0) transform.eulerAngles = Vector2.up * 0;
        if (rand == 1) transform.eulerAngles = Vector2.up * 180;

    }
    private Collider2D[] hits;
    private Collider2D[] hitresult;
    private void 檢查地板()
    {
        hits= Physics2D.OverlapCircleAll(transform.position + transform.right * checkfoor.x + transform.up * checkfoor.y, checkfoorint);
        //Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position + transform.right * checkfoor.x + transform.up * checkfoor.y, checkfoorint);
        hitresult = hits.Where(x => x.name != "拼圖地板Tilemap" && x.name != "跳台Tilemap" && x.name != "可穿透跳台" && x.name != "主角").ToArray();

        if (hits.Length == 0 || hitresult.Length>0)
        {
            print("沒有地板或者有障礙物");
            轉彎();
        }

    }
    public void 轉彎()
    {
        float y = transform.eulerAngles.y;
        if (y == 0) transform.eulerAngles =Vector3.up*180;
        else transform.eulerAngles = Vector3.zero;

    }
    public void 受傷(float 傷害值)
    {
        hp -= 傷害值;
        ani.SetTrigger("受傷");
        if (hp <= 0)
        {
            死亡();
        }
    }
    private void 死亡()
    {
        hp = 0;
        ani.SetBool("死亡",true);
        state = StateEnemy.dead;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.velocity = Vector2.zero;
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
        enabled = false;
        掉落物();
        傳送門管理.怪物數量--;
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0.3f, 0.3f,0.3f);
        Gizmos.DrawSphere(transform.position+ transform.right * checkfoor.x + transform.up * checkfoor.y, checkfoorint);
    }

    public GameObject 寶物;
    public float 掉落機率01 = 1;
    private void 掉落物()
    {
        if(Random.value<= 掉落機率01)
        {
            Instantiate(寶物, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        }
    }
}
