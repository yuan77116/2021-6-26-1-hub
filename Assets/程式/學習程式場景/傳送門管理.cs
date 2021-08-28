using UnityEngine;
using UnityEngine.Events;

public class 傳送門管理 : MonoBehaviour
{
    public bool 範圍內;
    public static int 怪物數量;
    private void Start()
    {
        怪物數量 = GameObject.FindGameObjectsWithTag("monster").Length;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player"&& 怪物數量 == 0)
        {
            範圍內 = true;
            onpass.Invoke();
        }
    }
    public UnityEvent onpass;
}
