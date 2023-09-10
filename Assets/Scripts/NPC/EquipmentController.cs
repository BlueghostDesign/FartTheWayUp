using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    private NPC npc;

    private Fade fade;

    public bool wearing;


    private void Awake()
    {
        npc = GetComponentInParent<NPC>();
        fade = GetComponent<Fade>();
        wearing = false;
    }

    private void Update()
    {
        Wear();
        UnWear();
    }

    private void Wear()
    {
        if (!npc.gotOff && !wearing)
        {
            if ((npc.cantHear && npc.cantSmell) || (npc.cantHear && gameObject.CompareTag("earphone")) || (npc.cantSmell && gameObject.CompareTag("mask")))
            {
                fade.SetFadeIn();
                wearing = true;
            }
        }
    }

    private void UnWear()
    {
        if (npc.gotOff && wearing)
        {
            fade.SetFadeOut();
            wearing = false;
        }
    }
}
