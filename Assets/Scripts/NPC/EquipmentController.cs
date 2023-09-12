using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    private NPC npc;

    private Fade fade;

    private bool wearing;


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
        if (!npc.OnBoard() || wearing)
        {
            return;
        }
        if ((npc.CantHear() && npc.CantSmell()) || (npc.CantHear() && gameObject.CompareTag("earphone")) ||
            (npc.CantSmell() && gameObject.CompareTag("mask")))
        {
            fade.SetFadeIn();
            wearing = true;
        }
    }

    private void UnWear()
    {
        if (!npc.OnBoard() && wearing)
        {
            fade.SetFadeOut();
            wearing = false;
        }
    }
}
