using UnityEngine;
using UnityEngine.UI;

public class NPCFloor : MonoBehaviour
{
    public Text npcFloor;

    private NPC npc;

    private Elevator elevator;


    private void Awake()
    {
        npc = GetComponentInParent<NPC>();
        elevator = GameObject.Find("Elevator").transform.GetComponent<Elevator>();
    }

    private void Update()
    {
        if (npc.OnBoard())
        {
            npcFloor.text = npc.GetFloor().ToString();
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
