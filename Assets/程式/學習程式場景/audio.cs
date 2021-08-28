using UnityEngine;
using UnityEngine.Audio;

public class audio : MonoBehaviour
{
    public AudioMixer mixer;
    public void 設定bgm音量(float a)
    {
        mixer.SetFloat("bgm",a);
    }
    public void 設定sfx音量(float b)
    {
        mixer.SetFloat("sfx", b);
    }
}
