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
        if (npc.OnBoard() && !shown)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
            shown = true;
        }
        else if(!npc.OnBoard() && shown)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
            shown = false;
        }
    }
}
