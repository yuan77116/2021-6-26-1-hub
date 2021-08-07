using UnityEngine;

/// <summary>
/// ��v���l�ܪ��a
/// </summary>
public class Cameraa1a2 : MonoBehaviour
{
    [Header("��v���t��"),Range(1,5)]
    public float speed = 3;
    [Header("�ؼЦW��")]
    public string nameTarget;
    [Header("���k����")]
    public Vector2 limitHorizontal;
    /// <summary>
    /// �n�l�����W��
    /// </summary>
    private Transform target;
    //public GameObject �ڦW;

    private void Start()
    {
        //�M�䪫��W��(�Y�į�)
        target = GameObject.Find(nameTarget).transform;
        //�ڦW = GameObject.Find("�ڦW");
    }
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// �l�ܥؼ�
    /// </summary>
    private void Track()
    {
        Vector3 posCamera = transform.position;
        Vector3 posTarget = target.position;
        //Lerp(a�I,b�I,���Τ��I���H�t��ex:0.5f)
        Vector3 posResult = Vector3.Lerp(posCamera, posTarget, speed * Time.deltaTime);

        //�����
        posResult.z = -10;
        //����k�d��
        posResult.x = Mathf.Clamp(posResult.x, limitHorizontal.x, limitHorizontal.y);

        transform.position = posResult;
    }

}
