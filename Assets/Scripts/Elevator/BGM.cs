using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource bgm;


    private void Start()
    {
        // Plays BGM at the start of the game.
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
