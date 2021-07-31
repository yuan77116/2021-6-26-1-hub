using UnityEngine;
using UnityEngine.SceneManagement; //引用場景管理API

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// 載入場景
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene("遊戲場景1"); //載入指定場景
    }
    public void DelayLoadGameScene()
    {
        Invoke("LoadGameScene", 0.7f);//延遲讓音效播完
    }
    /// <summary>
    /// 離開場景
    /// </summary>
    public void OuitGame()
    {
        Application.Quit(); //離開程式
        print("離開遊戲");  //unity內不會顯示執行否則沒存檔
    }
    public void DelayOuitGame()
    {
        Invoke("OuitGame", 0.7f); //延遲讓音效播完
    }
}
