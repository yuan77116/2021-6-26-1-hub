using UnityEngine;

public class apinostatic : MonoBehaviour
{
    //�D�R�A�ݭn�w�q���A���Ӥ���ŭȡC
    public Transform tA = null;
    public Camera ��v�� = null;
    public Transform tB = null;
    public Light light = null;
    #region �Ұ�
    public Camera ��v���`�� = null; 
    public SpriteRenderer �Ϥ�1 = null;
    public SpriteRenderer �Ϥ�2 = null;
    public SpriteRenderer �Ϥ�3 = null;
    public Rigidbody2D rig;
    #endregion
    private void Start()
    {
        print("���o�y�� " + tA);
        print("�I���C�� " + ��v��.backgroundColor);
        //��v��.backgroundColor = new Color(0,0.5f,0.6f);
        tB.transform.Translate(1, 0, 0);
        light.Reset();

        #region �Ұ�
        print("��v���`�� " + ��v���`��.depth);
        print("�Ϥ�1�C�� " + �Ϥ�1.color);
        //��v���`��.backgroundColor = new Color(Random.Range(0,255), Random.Range(0,255), Random.Range(0,255));
        ��v���`��.backgroundColor = Random.ColorHSV();
        �Ϥ�1.flipY=true;
        #endregion
    }
    private void Update()
    {
        #region �Ұ�
        �Ϥ�2.transform.Rotate(0, 0, 1);
        rig.AddForce(new Vector2(0, 10));
        #endregion
    }
}
