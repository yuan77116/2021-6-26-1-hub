using UnityEngine;

public class player : MonoBehaviour
{
    #region �Ұ�m��

    [Header("���ʳt��"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("���D����"), Range(0, 3000)]
    public int playerjump = 100;
    [Header("��q"),Range(0,200)]
    public float hp = 100;
    [Header("�O�_�b�a�O�W"),Tooltip("�I��a�O?")]
    public bool isground = false;

    private  AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion
    #region ��k�m��
    //���
    [Range(-1, 1)]
    public float �t��=0;
    public bool ��=false;
    //�ƥ�
    private void Start()
    {
        Move(0);
        Jump();
        Atk();
        Hurt(0);
        Dead();
        ErtProp("��");
    }
    //��k

    ///<summary>
    ///����
    /// </summary>
    /// ///<param name="x�b��V">���Ⲿ�ʤ�V</param>
    private void Move(float x�b��V)
    {
        
    }
    ///<summary>
    ///���D
    /// </summary>
    private void Jump()
    {

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
