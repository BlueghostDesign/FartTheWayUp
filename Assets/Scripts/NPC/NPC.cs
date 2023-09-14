using UnityEngine;

public class NPC : MonoBehaviour
{
    private bool isNPC;

    private bool cantHear;

    private bool cantSmell;

    private int hearing;

    private int smelling;

    public int startFloor;

    private int floor;

    private float anger;

    private float angryLevel;

    private bool availiable;

    private bool gotOff;

    private int onOrOff;

    private float time;

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
        if (availiable && elevator.Stopped() && elevator.GetFloor() >= startFloor && gotOff)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                availiable = false;
                onOrOff = Random.Range(0, 2);
                if (onOrOff == 1)
                {
                    gotOff = false;
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
                    SelectFloor();
                    fade.SetFadeIn();
                }
                time = 2;
            }
        }
        else if (elevator.IsMoving() && gotOff)
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
        if (elevator.GetFloor() == floor && isNPC && !gotOff)
        {
            fade.SetFadeOut();
            anger = 0;
            angryLevel = 0;
            SetAngerBar();
            cantHear = false;
            cantSmell = false;
            gotOff = true;
            availiable = true;
        }
    }

    public bool OnBoard()
    {
        return !gotOff;
    }

    public int GetFloor()
    {
        return floor;
    }

    public float GetAnger()
    {
        return anger;
    }

    public void GainAnger(float amount)
    {
        anger += amount;
    }

    public void ReduceAnger(float amount)
    {
        anger -= amount;
    }

    public float GetAngryLevel()
    {
        return angryLevel;
    }

    public bool CantHear()
    {
        return cantHear;
    }

    public bool CantSmell()
    {
        return cantSmell;
    }
}
