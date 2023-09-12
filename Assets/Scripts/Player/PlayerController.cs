using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float fartAmount;

    private bool hasFart;

    private bool eating;

    private float time;

    private int fartType;

    private bool clearing;

    private bool fartReseted;

    private IEnumerator coroutine;

    private bool spacePressed;

    private FartCheck fartCheck;

    private FartAnimation fartAnimation;

    private FartBar fartBar;

    private Elevator elevator;


    private void Awake()
    {
        fartAmount = 0;
        coroutine = WaitAndCount(1/60f);
        spacePressed = false;
        fartCheck = GetComponentInParent<FartCheck>();
        fartAnimation = GetComponentInChildren<FartAnimation>();
        fartBar = GetComponentInChildren<FartBar>();
        elevator = GetComponentInParent<Elevator>();
        hasFart = false;
        eating = false;
        time = 3;
        clearing = false;
        fartReseted = false;
    }


    private void Update()
    {
        SetFartBar();
        CheckFart();
        Fart();
        ResetFart();
        IsEating();
        ClearFart();
        fartCheck.SetPlayerHasFart(hasFart);
    }

    private void SetFartBar()
    {
        fartBar.FartChange(fartAmount / 100);
    }

    private void Fart()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!spacePressed && hasFart)
            {
                StartCoroutine(coroutine);
                spacePressed = true;
            }
            else if (!hasFart)
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
            UpdateFartAmount();
        }
    }

    private void UpdateFartAmount()
    {
        if (elevator.GetSpeed() == 1)
        {
            fartAmount -= (100f / 10f) / 60f;
        }
        else if (elevator.GetSpeed() == 2)
        {
            fartAmount -= (100f / 8f) / 60f;
        }
        else if (elevator.GetSpeed() == 3)
        {
            fartAmount -= (100f / 6.5f) / 60f;
        }
        else if (elevator.GetSpeed() == 4)
        {
            fartAmount -= (100f / 5f) / 60f;
        }
        else if (elevator.GetSpeed() == 5)
        {
            fartAmount -= (100f / 3.5f) / 60f;
        }
    }

    private void CheckFart()
    {
        if (fartAmount > 0)
        {
            hasFart = true;
        }
        else
        {
            hasFart = false;
        }
    }

    public bool HasFart()
    {
        return hasFart;
    }

    public float GetFartAmount()
    {
        return fartAmount;
    }

    public void Eat(int type)
    {
        eating = true;
        fartType = type;
    }

    private void IsEating()
    {
        if (eating)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                fartReseted = false;
                eating = false;
                time = 3;
                if (clearing)
                {
                    return;
                }
                if (fartType == 1)
                {
                    fartCheck.SetLoud();
                    AddFart();
                }
                else if (fartType == 2)
                {
                    fartCheck.SetStinky();
                    AddFart();
                }
                else
                {
                    clearing = true;
                    fartCheck.SetPlayerClearingFart();
                }
                if (fartAmount >= 100)
                {
                    GameManager.GameOver();
                }
            }
        }
    }

    public void AddFart()
    {
        if (elevator.GetSpeed() == 1)
        {
            fartAmount += 24;
        }
        else if (elevator.GetSpeed() == 2)
        {
            fartAmount += 33;
        }
        else if (elevator.GetSpeed() == 3)
        {
            fartAmount += 42;
        }
        else if (elevator.GetSpeed() == 4)
        {
            fartAmount += 58.5f;
        }
        else if (elevator.GetSpeed() == 5)
        {
            fartAmount += 84;
        }
    }

    private void ClearFart()
    {
        if (clearing && hasFart)
        {
            if (fartType == 3)
            {
                fartCheck.ResetLoud();
                fartCheck.ResetStinky();
                fartCheck.SetRainbow();
            }
            UpdateFartAmount();
            fartAnimation.StartClearing();
        }
        else
        {
            clearing = false;
            fartCheck.ResetPlayerClearingFart();
            fartAnimation.StopClearing();
        }
    }

    private void ResetFart()
    {
        if (!hasFart && !fartReseted)
        {
            fartCheck.ResetLoud();
            fartCheck.ResetStinky();
            fartCheck.ResetRainbow();
            fartReseted = true;
        }
    }

    public bool GetEating()
    {
        return eating;
    }
}
