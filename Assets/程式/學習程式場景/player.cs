using UnityEngine;

public class player : MonoBehaviour
{
    #region �Ұ�m��

    [Header("���ʳt��"), Range(0, 300)]
    public float speed = 150;
    [Header("���D����"), Range(0, 10)]
    public int playerjump = 2;
    [Header("��q"), Range(0, 200)]
    public float hp = 100;
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
        ani.SetBool("����", horizontal!=0);
    }
    [Header("�t���O"),Range(0.01f,1)]
    public float gravity=0.45f;
    ///<summary>
    ///���D
    /// </summary>
    private void Jump()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundOffest, groundRadius,1<<6); //�]�i��v3 1<<6 �ϥΪ��ϼh [ <<�첾�B��l 1<<�ϼh�s�� ]
        if (hit)
        {
            print("�I�쪺���� " + hit);
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
        }
        if (isatk)
        {
            if(timer< acd)
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
        
    }
    ///<summary>
    ///���`
    /// </summary>
    private void Dead()
    {
        
    }
    ///<summary>
    ///�߰_���D��W
    /// </summary>
    /// ///<param name="�D��W��">�߰_���D��W��</param>
    private void ErtProp(string �D��W��)
    {
        print("�Y��G" + �D��W��);
    }
    //ø�s�ϥܨƥ�
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //Gizmos.DrawSphere(transform.position,2); //(�����I�A�b�|)
        Gizmos.DrawSphere(transform.position + groundOffest, groundRadius);
    }
    #endregion
}
