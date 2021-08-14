using UnityEngine;

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
    private StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;

    public Vector2 v2idle = new Vector2(1, 5);
    public Vector2 v2walk = new Vector2(3, 6);

    private float timeidle;
    private float timeridle;
    private float timewalk;
    private float timerwalk;

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
    }
    private void Update()
    {
        檢查狀態();
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

                break;
            case StateEnemy.dead:

                break;
            //--------
            default:
                print("狀態不明");
                break;
        }
    }
    private void idle()
    {
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
    }
    private void 隨機方向()
    {
        int rand = Random.Range(0,2); //= 0 or 1 !=2
        if (rand == 0) transform.eulerAngles = Vector2.up * 0;
        if (rand == 1) transform.eulerAngles = Vector2.up * 180;

    }
}
