using UnityEngine;
using UnityEngine.Audio;

public class audio : MonoBehaviour
{
    public AudioMixer mixer;
    public void �]�wbgm���q(float a)
    {
        mixer.SetFloat("bgm",a);
    }
    public void �]�wsfx���q(float b)
    {
        mixer.SetFloat("sfx", b);
    }
}
