using UnityEngine;

public class player : MonoBehaviour
{
    #region 課堂練習

    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int playerjump = 100;
    [Header("血量"),Range(0,200)]
    public float hp = 100;
    [Header("是否在地板上"),Tooltip("碰到地板?")]
    public bool isground = false;

    private  AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion
}
