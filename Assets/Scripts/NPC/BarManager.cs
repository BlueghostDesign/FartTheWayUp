using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    private NPC npc;

    public Image img;

    private bool shown;


    private void Awake()
    {
        npc = GetComponentInParent<NPC>();
        shown = false;
    }

    private void Update()
    {
        // Show the anger bar when the NPC gets onboard.
        // This process only runs once everytime the NPC got onboard.
        if (npc.OnBoard() && !shown)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
            shown = true;
        }
        // Hide the anger bar when the NPC gets off.
        // This process only runs once everytime the NPC gets off.
        else if (!npc.OnBoard() && shown)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
            shown = false;
        }
    }
}
