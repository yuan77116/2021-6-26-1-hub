using UnityEngine;

/// <summary>
/// 攝影機追蹤玩家
/// </summary>
public class Cameraa1a2 : MonoBehaviour
{
    [Header("攝影機速度"),Range(1,5)]
    public float speed = 3;
    [Header("目標名稱")]
    public string nameTarget;
    [Header("左右限制")]
    public Vector2 limitHorizontal;
    /// <summary>
    /// 要追中的名稱
    /// </summary>
    private Transform target;
    //public GameObject 我名;

    private void Start()
    {
        //尋找物件名稱(吃效能)
        target = GameObject.Find(nameTarget).transform;
        //我名 = GameObject.Find("我名");
    }
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 追蹤目標
    /// </summary>
    private void Track()
    {
        Vector3 posCamera = transform.position;
        Vector3 posTarget = target.position;
        //Lerp(a點,b點,分割中點跟隨速度ex:0.5f)
        Vector3 posResult = Vector3.Lerp(posCamera, posTarget, speed * Time.deltaTime);

        //限制遠近
        posResult.z = -10;
        //限制左右範圍
        posResult.x = Mathf.Clamp(posResult.x, limitHorizontal.x, limitHorizontal.y);

        transform.position = posResult;
    }

}
