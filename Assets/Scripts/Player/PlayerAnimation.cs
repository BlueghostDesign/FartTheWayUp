using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAnimation()
    {
        anim.SetTrigger("eatFood");
    }
}
