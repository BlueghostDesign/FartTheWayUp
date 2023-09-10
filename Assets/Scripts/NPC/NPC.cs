using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool isNPC;

    public bool cantHear;

    public bool cantSmell;

    public int hearing;

    public int smelling;

    public int startFloor;

    public int floor;

    public float anger;

    public float angryLevel;

    public bool availiable;

    public bool gotOff;

    public int onOrOff;

    public float time;

    private AngerAmount angerAmount;

    private Elevator elevator;

    private Fade fade;


    private void Awake()
    {
        anger = 0;
        angryLevel = 0;
        angerAmount = GetComponentInChildren<AngerAmount>();
        elevator = gameObject.GetComponentInParent<Elevator>();
        fade = GetComponent<Fade>();
        availiable = true;
        gotOff = true;
        isNPC = gameObject.CompareTag("NPC");
        if (isNPC)
        {
            SetAngerBar();
        }
        time = 2;
    }

    private void Update()
    {
        GetOn();
        if (!gotOff)
        {
            AngryLevel();
            SetAngerBar();
            GetOff();
        }
    }

    private void GetOn()
    {
        if (availiable && elevator.stopped && elevator.floor >= startFloor && gotOff)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                availiable = false;
                onOrOff = Random.Range(0, 2);
                if (onOrOff == 1)
                {
                    SelectFloor();
                    fade.SetFadeIn();
                    gotOff = false;
                    availiable = true;
                    hearing = Random.Range(0, 2);
                    smelling = Random.Range(0, 2);
                    if (hearing == 0)
                    {
                        cantHear = true;
                    }
                    if (smelling == 0)
                    {
                        cantSmell = true;
                    }
                }
                time = 2;
            }
        }
        else if (elevator.moving)
        {
            availiable = true;
        }
    }

    public void SelectFloor()
    {
        floor = elevator.stops[Random.Range(0, elevator.stops.Count)];
    }

    private void AngryLevel()
    {
        if (anger >= 66)
        {
            angryLevel = 2;
        }
        else if (anger >= 33)
        {
            angryLevel = 1;
        }
        else
        {
            angryLevel = 0;
        }
    }

    private void SetAngerBar()
    {
        angerAmount.AngerChange(anger / 100);
    }

    private void GetOff()
    {
        if (elevator.floor == floor && isNPC && !gotOff)
        {
            fade.SetFadeOut();
            anger = 0;
            angryLevel = 0;
            SetAngerBar();
            cantHear = false;
            cantSmell = false;
            gotOff = true;
        }
    }

    public float GetAnger()
    {
        return anger;
    }

    public float GetAngryLevel()
    {
        return angryLevel;
    }
}
