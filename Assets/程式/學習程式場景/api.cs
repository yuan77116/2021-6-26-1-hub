using UnityEngine;


///<summary>
///
/// </summary>
public class api : MonoBehaviour
{
    //Api �R�A = ��static
    //Api �ʺA = �Lstatic
    //Static Properties �ݩ�
    //Static Methods ��k

    //private void Start()
    //{
    //    print("�H���� " + Random.value);
    //    print("�L���j " + Mathf.Infinity);
    //    print("�t�L���j " + Mathf.NegativeInfinity);
    //    Cursor.visible = true;
    //    Screen.fullScreen = true;
    //    print(Random.Range(100.009f,300));
    //    float r = Random.Range(1.5f, 7.5f);
    //    print("�H��7.5~1.5 "+r);
    //}
    //[Range(0,100)]
    //public float hp=100;
    //private void Update()
    //{
    //    hp = Mathf.Clamp(hp, 0, 100);
    //    print("��q " + hp);
    //}

    #region �Ұ�m��
    //���o
    public float m = 9.999f;
    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(22,22,22);

    private void Start()
    {
        //�]�w
        Physics2D.gravity = new Vector2(0, -20);
        Time.timeScale = 0.5f;   //�Ȱ�/��t0~1�t��
        //��k
        print("��v���ƶq = "+ Camera.allCamerasCount);
        print("���O�j�p = " + Physics2D.gravity);
        print("��P�v = " + Mathf.PI);
        //��k
        print("m = " + Mathf.Abs(m));
        float c = Vector3.Distance(a, b);
        print("a.b�Z�� = " + c);
        //�}����
        Application.OpenURL("https://unity.com/");
    }

    private void Update()
    {
        print("�O�_��J���N�� = " + Input.anyKey);
        print("�C���g�L�ɶ� = " + Time.time);
        //��k
        bool space = Input.GetKeyDown("space");
        print("���Uspace = " + space);
    }
         //Mathf.Round (1.2f)  ��X: 1
         // Mathf.Round(1.6f)  ��X: 2

         //Mathf.Round(1.5f)  ��X: 2
         //Mathf.Round(2.5f)  ��X: 2

         //2. �L����i��
         //Mathf.Ceil(1.2f)  ��X: 2
         //Mathf.Ceil(1.6f)  ��X: 2

         //3. �L����˥h
         //Mathf.Floor(1.2f)  ��X: 1
         //Mathf.Floor(1.6f)  ��X: 1

         //4. �����
         //Mathf.Abs(1.2f)  ��X: 1.2
         //Mathf.Abs(-1.6f)  ��X: 1.6
    #endregion

}
