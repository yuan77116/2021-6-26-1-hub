using UnityEngine;

public class player : MonoBehaviour
{
    #region �Ұ�m��

    [Header("���ʳt��"), Range(0, 100)]
    public float speed = 10.5f;
    [Header("���D����"), Range(0, 30)]
    public int playerjump = 10;
    [Header("��q"), Range(0, 200)]
    public float hp = 100;
    [Header("�O�_�b�a�O�W"), Tooltip("�I��a�O?")]
    public bool isground = false;

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
    }
    //��í�w60��
    private void Update()
    {
        GetPlayerHorizontal();
        Jump();
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
    {
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity,0) * speed * Time.fixedDeltaTime;
        rig.MovePosition(posMove);
    }
    [Header("�t���O"),Range(0.01f,1)]
    public float gravity=0.45f;
    ///<summary>
    ///���D
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            rig.AddForce(new Vector2(0, playerjump*200));
        }
    }
    ///<summary>
    ///����
    /// </summary>
    private void Atk()
    {
        
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

    #endregion
}
