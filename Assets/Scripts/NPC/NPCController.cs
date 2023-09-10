using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public bool spacePressed;

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
            if (!spacePressed && fartCheck.PlayerHasFart() && !npc.gotOff)
            {
                if ((fartCheck.IsLoud() && fartCheck.IsStinky() && (!npc.cantHear || !npc.cantSmell)) || 
                    (fartCheck.IsLoud() && !npc.cantHear) || (fartCheck.IsStinky() && !npc.cantSmell))
                {
                    StartCoroutine(coroutine);
                    spacePressed = true;
                }
            }
            if (!fartCheck.PlayerHasFart() || npc.gotOff)
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
        if (elevator.GetSpeed() == 1)
        {
            npc.anger += (100f / 8f) / 60f;
        }
        else if (elevator.GetSpeed() == 2)
        {
            npc.anger += (100f / 6f) / 60f;
        }
        else if (elevator.GetSpeed() == 3)
        {
            npc.anger += (100f / 4f) / 60f;
        }
        else if (elevator.GetSpeed() == 4)
        {
            npc.anger += (100f / 3f) / 60f;
        }
        else if (elevator.GetSpeed() == 5)
        {
            npc.anger += (100f / 2f) / 60f;
        }
    }

    private void ReduceAnger()
    {
        if (elevator.GetSpeed() == 1)
        {
            npc.anger -= (100f / 10f) / 60f;
        }
        else if (elevator.GetSpeed() == 2)
        {
            npc.anger -= (100f / 8f) / 60f;
        }
        else if (elevator.GetSpeed() == 3)
        {
            npc.anger -= (100f / 6f) / 60f;
        }
        else if (elevator.GetSpeed() == 4)
        {
            npc.anger -= (100f / 4f) / 60f;
        }
        else if (elevator.GetSpeed() == 5)
        {
            npc.anger -= (100f / 3f) / 60f;
        }
    }

    private void FartClearing()
    {
        if (fartCheck.GetPlayerClearingFart() && !npc.gotOff)
        {
            if (fartCheck.IsRainbow())
            {
                ReduceAnger();
            }
            else if ((fartCheck.IsLoud() && fartCheck.IsStinky() && (!npc.cantHear || !npc.cantSmell)) ||
                    (fartCheck.IsLoud() && !npc.cantHear) || (fartCheck.IsStinky() && !npc.cantSmell))
            {
                GainAnger();
            }
        }
    }

    private void SetAnimation()
    {
        anim.SetFloat("angryLevel", npc.angryLevel);
    }

    private void Gameover()
    {
        if (npc.anger >= 100)
        {
            GameManager.GameOver();
        }
    }
}
