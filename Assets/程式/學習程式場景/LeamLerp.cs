using UnityEngine;

public class LeamLerp : MonoBehaviour
{
    //�{�Ѯt��
    public float a = 0, b = 10;
    public float result;
    public Vector2 a1;
    public Vector2 a2;

    private void Start()
    {
        // Lerp 2�I��������
        result = Mathf.Lerp(a, b, 0.5f);
    }
    private void Update()
    {
        a = Mathf.Lerp(a, b, 0.5f*Time.deltaTime);
        a1 = Vector2.Lerp(a1, a2, 0.65f * Time.deltaTime);
    }
}
