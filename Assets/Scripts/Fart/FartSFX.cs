using UnityEngine;

public class FartSFX : MonoBehaviour
{
    private AudioSource fart;


    private void Start()
    {
        fart = GetComponent<AudioSource>();
    }

    public void PlayFartSound()
    {
        fart.Play();
    }
}
