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
}
