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


    private void Awake()
    {
        coroutine = WaitAndCount(1 / 60f);
        anim = GetComponent<Animator>();
        npc = GetComponent<NPC>();
        fartCheck = GetComponentInParent<FartCheck>();
        elevator = GetComponentInParent<Elevator>();
    }

    private void Update()
    {
        Gameover();
        Angry();
        SetAnimation();
        FartClearing();
    }

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

    private void GainAnger()
    {
        if (elevator.stopped)
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

    private void SetAnimation()
    {
        anim.SetFloat("angryLevel", npc.GetAngryLevel());
    }

    private void Gameover()
    {
        if (npc.GetAnger() >= 100)
        {
            GameManager.GameOver();
        }
    }
}
