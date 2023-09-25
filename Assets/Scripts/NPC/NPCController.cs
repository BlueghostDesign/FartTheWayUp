using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private bool spacePressed;

    private IEnumerator coroutine;

    private Animator anim;

    private NPC npc;

    private FartCheck fartCheck;

    private Elevator elevator;

    public float c;

    public float c2;


    private void Awake()
    {
        coroutine = WaitAndCount(1 / 60f);
        anim = GetComponent<Animator>();
        npc = GetComponent<NPC>();
        fartCheck = GetComponentInParent<FartCheck>();
        elevator = GetComponentInParent<Elevator>();
        c = 0;
        c2 = 0;
    }

    private void Update()
    {
        Gameover();
        Angry();
        FartClearing();
        ItemUsed();
        SetAnimation();
    }

    // Increase the anger of effected onboard NPCs when the player farts.
    private void Angry()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!spacePressed && fartCheck.PlayerHasFart() && npc.OnBoard())
            {
                if ((fartCheck.IsLoud() && !npc.CantHear()) || (fartCheck.IsStinky() && !npc.CantSmell()))
                {
                    StartCoroutine(coroutine);
                    spacePressed = true;
                }
            }
            if (!fartCheck.PlayerHasFart() || !npc.OnBoard())
            {
                StopCoroutine(coroutine);
                spacePressed = false;
            }
        }
        else
        {
            StopCoroutine(coroutine);
            spacePressed = false;
        }
    }

    private IEnumerator WaitAndCount(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GainAnger();
        }
    }

    // Gain effected NPCs' anger according to the elevator speed.
    private void GainAnger()
    {
        if (elevator.Stopped())
        { 
            return; 
        }
        if (elevator.GetSpeed() == 1)
        {
            npc.GainAnger((100f / 8f) / 60f);
        }
        else if (elevator.GetSpeed() == 2)
        {
            npc.GainAnger((100f / 7f) / 60f);
        }
        else if (elevator.GetSpeed() == 3)
        {
            npc.GainAnger((100f / 6f) / 60f);
        }
        else if (elevator.GetSpeed() == 4)
        {
            npc.GainAnger((100f / 4.5f) / 60f);
        }
        else if (elevator.GetSpeed() == 5)
        {
            npc.GainAnger((100f / 3f) / 60f);
        }
    }

    // Gain effected NPCs' anger according to player's farting speed.
    private void ReduceAnger()
    {
        if (elevator.GetSpeed() == 1)
        {
            npc.ReduceAnger((100f / 10f) / 60f);
        }
        else if (elevator.GetSpeed() == 2)
        {
            npc.ReduceAnger((100f / 8f) / 60f);
        }
        else if (elevator.GetSpeed() == 3)
        {
            npc.ReduceAnger((100f / 6.5f) / 60f);
        }
        else if (elevator.GetSpeed() == 4)
        {
            npc.ReduceAnger((100f / 5f) / 60f);
        }
        else if (elevator.GetSpeed() == 5)
        {
            npc.ReduceAnger((100f / 3.5f) / 60f);
        }
    }

    // Force player to clear farts if player ate rainbow candy or pill.
    private void FartClearing()
    {
        if (fartCheck.GetPlayerClearingFart() && npc.OnBoard() && npc.GetAnger() > 0)
        {
            if (fartCheck.IsRainbow())
            {
                ReduceAnger();
            }
            else if ((fartCheck.IsLoud() && !npc.CantHear()) || (fartCheck.IsStinky() && !npc.CantSmell()))
            {
                GainAnger();
            }
        }
    }

    private void ItemUsed()
    {
        if (!npc.OnBoard())
        {
            return;
        }
        int item = elevator.GetItemUsed();
        // Instant reduce of anger according to the used item.
        if (item == 1 || item == 2 || item == 3)
        {
            if (npc.GetAnger() >= ((float)item / 3f) * 100f)
            {
                npc.ReduceAnger(((float)item / 3f) * 100f);
            }
            else
            {
                npc.ReduceAnger(npc.GetAnger());
            }
            // This NPC is effected by the item.
            elevator.PassengerEffected();
        }
    }

    private void SetAnimation()
    {
        anim.SetFloat("angryLevel", npc.GetAngryLevel());
    }

    private void Gameover()
    {
        // Gameover if NPC's anger is over 100.
        if (npc.GetAnger() >= 100)
        {
            GameManager.GameOver();
        }
    }
}
