using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource bgm;


    private void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    public void StartBGM()
    {
        bgm.Play();
    }

    public void StopBGM()
    {
        bgm.Stop();
    }
}
