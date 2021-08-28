using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover控制 : MonoBehaviour
{
    public Animator ani;
    public Text 標題;
    public Text 文字;
    public string 標題內容;
    public string 文字內容;
    public KeyCode q =KeyCode.Q;
    public KeyCode r = KeyCode.R;
    private bool 遊戲結束;

    public void 是否結束(bool win)
    {
        遊戲結束 = true;
        ani.enabled = true;

        if (win)
        {
            標題內容 = "勝利";
            標題.text = 標題內容;
        }
        else
        {
            標題內容 = "失敗";
            標題.text = 標題內容;
        }
    }
    private void Update()
    {
        if (遊戲結束)
        {
            if (Input.GetKeyDown(r))
            {
                SceneManager.LoadScene("遊戲場景1");
                遊戲結束 = false;
            }
            if (Input.GetKeyDown(q))
            {
                Application.Quit();
                遊戲結束 = false;
            }
        }
    }
}
