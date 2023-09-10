using UnityEngine;
using UnityEngine.UI;

public class NPCFloor : MonoBehaviour
{
    public Text npcFloor;

    public bool fadeIn;

    public bool fadeOut;

    private NPC npc;

    private Elevator elevator;


    private void Awake()
    {
        fadeIn = false;
        fadeOut = false;
        npc = GetComponentInParent<NPC>();
        elevator = GameObject.Find("Elevator").transform.GetComponent<Elevator>();
    }

    private void Update()
    {
        if (!npc.gotOff)
        {
            npcFloor.text = npc.floor.ToString();
            if (elevator.stopped)
            {
                npcFloor.color = new Color(npcFloor.color.r, npcFloor.color.g, npcFloor.color.b, 1);
            }
            else
            {
                npcFloor.color = new Color(npcFloor.color.r, npcFloor.color.g, npcFloor.color.b, 0);
            }
        }
        else
        {
            npcFloor.color = new Color(npcFloor.color.r, npcFloor.color.g, npcFloor.color.b, 0);
        }
    }
}
