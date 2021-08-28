using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    public UnityEvent ���`�ƥ�;
    #region �Ұ�m��
    [Header("�����O"), Range(0, 300)]
    public float �����O = 10;
    [Header("���ʳt��"), Range(0, 300)]
    public float speed = 150;
    [Header("���D����"), Range(0, 10)]
    public int playerjump = 2;
    [Header("��q"), Range(0, 200)]
    public float hp = 100;
    private float �̤jhp;
    [Header("�O�_�b�a�O�W"), Tooltip("�I��a�O?")]
    public bool isground = false;
    [Header("�ˬd�a�O�ϰ�G�첾�P�b�|")]
    public Vector3 groundOffest;
    [Range(0, 2)]
    public float groundRadius = 0.5f;
    [Header("2�q��")]
    private int jump2 = 0;
    [Header("�N�o�ɶ�")]
    private float acd = 1.2f;
    /// <summary>
    /// �����p�ɾ�
    /// </summary>
    private float timer;
    /// <summary>
    /// �O�_����
    /// </summary>
    private bool isatk;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private Cameraa1a2 cameraa;

    private Text ��qhp;
    private Image �Ϥ�hp;
    #endregion
    #region ��k�m��
    //���
    //public float �t��=0;
    //public bool ��=false;
    //�ƥ�
    private void Start()
    {
        //Move(0);
        //Jump();
        //Atk();
        //Hurt(0);
        //Dead();
        //ErtProp("��");
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        ��qhp = GameObject.Find("��r��q").GetComponent<Text>();
        �Ϥ�hp = GameObject.Find("���").GetComponent<Image>();
        �̤jhp = hp;
        cameraa = GameObject.Find("Main Camera").GetComponent<Cameraa1a2>();
    }
    //��í�w60��
    private void Update()
    {
        GetPlayerHorizontal();
        Jump();
        Atk();
    }
    //í�w50��
    private void FixedUpdate()
    {
        Move(hValue);
    }
    //��k
    ///<summary>
    ///x��V
    /// </summary>
    private float hValue;
    /// ///<param name="x�b��V">�����V</param>
    private void GetPlayerHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");
        //print("���a������ "+hValue);
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
    ///����
    /// </summary>
    /// ///<param name="horizontal">���Ⲿ�ʤ�V</param>
    private void Move(float horizontal)
    {       /**�Ĥ@�ؼg�k �ۭq���O
            //Vector2 posMove = transform.position + new Vector3(horizontal,-gravity,0) * speed * Time.fixedDeltaTime;
            rig.MovePosition(posMove);**/
        //�ĤG�ؼg�k ���z�[�t�׮ĪG (���t�n�W�[.���D�n���)
        rig.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, rig.velocity.y);
        ani.SetBool("����", horizontal != 0);
    }
    [Header("�t���O"), Range(0.01f, 1)]
    public float gravity = 0.45f;
    ///<summary>
    ///���D
    /// </summary>
    private void Jump()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundOffest, groundRadius, 1 << 6); //�]�i��v3 1<<6 �ϥΪ��ϼh [ <<�첾�B��l 1<<�ϼh�s�� ]
        if (hit)
        {
            print("�I�쪺���� " + hit);
            isground = true;
            jump2 = 0;
        }
        else isground = false;

        if (Input.GetKeyDown(KeyCode.K) && jump2 != 2)
        {
            rig.velocity = Vector2.zero;
            jump2++;
            rig.AddForce(new Vector2(0, playerjump * 200));
            aud.PlayOneShot(���ĸ��D, Random.Range(0.7f, 1.1f)); //�n���j�p
        }
        ani.SetBool("���D", !isground);
    }
    ///<summary>
    ///����
    /// </summary>
    private void Atk()
    {
        if (!isatk && Input.GetKeyDown(KeyCode.J))
        {
            isatk = true;
            ani.SetTrigger("����");

            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * v2�����ϰ�.x + transform.up * v2�����ϰ�.y, v3�ؤo, 0, 1 << 8);
            if (hit)
            {
                print(hit.name);
                hit.GetComponent<�Ǫ�����>().����(�����O);
                StartCoroutine(cameraa.�̰�());
            }
        }
        if (isatk)
        {
            if (timer < acd)
            {
                timer += Time.deltaTime;
                //print("�����֥[�ɶ� " + timer);
            }
            else
            {
                timer = 0;
                isatk = false;
            }
        }
    }
    ///<summary>
    ///����
    /// </summary>
    /// ///<param name="�y�����ˮ`">������F�h�ֶˮ`</param>
    public void Hurt(float �y�����ˮ`)
    {
        hp -= �y�����ˮ`;
        ani.SetTrigger("����");
        if (hp <= 0)
        {
            Dead();
        }
        ��qhp.text = "��q " + hp;
        �Ϥ�hp.fillAmount = (hp / �̤jhp);
    }
    ///<summary>
    ///���`
    /// </summary>
    private void Dead()
    {
        hp = 0;
        ani.SetBool("���`", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.velocity = Vector2.zero;
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
        enabled = false;
        ���`�ƥ�.Invoke();
    }
    ///<summary>
    ///�߰_���D��W
    /// </summary>
    /// ///<param name="�D��W��">�߰_���D��W��</param>
    private void ErtProp(string �D��W��)
    {
        switch (�D��W��)
        {
            case "�����D��":
                print("�Y��G" + �D��W��);
                Destroy(hit������,0.2f);
                hp = Mathf.Clamp(hp, 0, �̤jhp);
                hp += 10;
                ��qhp.text = "��q " + hp;
                �Ϥ�hp.fillAmount = (hp / �̤jhp);
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ErtProp(collision.gameObject.tag);
        if (collision.transform.tag == "�����D��")
        {
            hit������ = collision.gameObject;
        }

    }
    private GameObject hit������;
    //ø�s�ϥܨƥ�
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //Gizmos.DrawSphere(transform.position,2); //(�����I�A�b�|)
        Gizmos.DrawSphere(transform.position + groundOffest, groundRadius);
        Gizmos.color = new Color(1, 0.3f, 0.1f, 0.3f);
        Gizmos.DrawCube(transform.position + transform.right * v2�����ϰ�.x + transform.up * v2�����ϰ�.y, v3�ؤo);
    }
    #endregion
    [Header("�����ϰ�")]
    public Vector2 v2�����ϰ�;
    public Vector3 v3�ؤo;
    public AudioClip ���ĸ��D;
}
