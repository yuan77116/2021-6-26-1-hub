using UnityEngine;
using UnityEngine.SceneManagement; //�ޥγ����޲zAPI

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// ���J����
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene("�C������1"); //���J���w����
    }
    /// <summary>
    /// ���}����
    /// </summary>
    public void OuitGame()
    {
        Application.Quit(); //���}�{��
        print("���}�C��");  //unity�����|��ܰ���_�h�S�s��
    }
}
