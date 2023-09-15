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
        // Return if NPC is already wearing this equipment or has already got off the elevator.
        if (!npc.OnBoard() || wearing)
        {
            return;
        }
        // Wear this equipment according to NPC's status.
        if ((npc.CantHear() && npc.CantSmell()) || (npc.CantHear() && gameObject.CompareTag("earphone")) ||
            (npc.CantSmell() && gameObject.CompareTag("mask")))
        {
            fade.SetFadeIn();
            wearing = true;
        }
    }

    private void UnWear()
    {
        // Unwear this equipment according to NPC's status if NPC got off and were wearing this equipment.
        if (!npc.OnBoard() && wearing)
        {
            fade.SetFadeOut();
            wearing = false;
        }
    }
}
