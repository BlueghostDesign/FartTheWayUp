using UnityEngine;

public class FartAnimation : MonoBehaviour
{
    private Animator anim;

    private FartCheck fartCheck;

    private bool clearing;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        fartCheck = GameObject.Find("Elevator").transform.GetComponent<FartCheck>();
    }

    private void Update()
    {
        if (!clearing)
        {
            if (Input.GetKey(KeyCode.Space) && fartCheck.PlayerHasFart())
            {
                SetAnimation(true);
            }
        }
    }

    public void SetAnimation(bool fart)
    {
        if (fartCheck.IsRainbow())
        {
            anim.SetBool("isRainbow", true);
        }
        anim.SetBool("fart", fart);
    }

    public void StartClearing()
    {
        SetAnimation(true);
        clearing = true;
    }

    public void StopClearing()
    {
        SetAnimation(false);
        anim.SetBool("isRainbow", false);
        clearing = false;
    }
}
