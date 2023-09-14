using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private int floor;

    public List<int> stops = new();

    private bool stopped;

    private bool moving;

    private bool cleared;

    private float stopTime;

    private float stopTimeCounter;

    private IEnumerator coroutine;

    private float speed;

    private int speedLevel;


    private void Awake()
    {
        floor = 0;
        speed = 1;
        speedLevel = 1;
        stopped = true;
        moving = false;
        cleared = false;
        stopTime = 3;
        stops.Add(0);
        stopTimeCounter = stopTime;
        coroutine = WaitAndCount();
    }

    private void Update()
    {
        AddNewStop();
        Speed();
        MoveUp();
        Arrive();
        StopCounter();
    }

    private void MoveUp()
    {
        if (!stopped && !moving)
        {
            StartCoroutine(coroutine);
            moving = true;
        }
    }

    private IEnumerator WaitAndCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/speed);
            floor += 1;
        }
    }

    public void AddNewStop()
    {
        if (stops.Count < 3)
        {
            int newStop = CreateNewStop();
            if (!stops.Contains(newStop))
            {
                stops.Add(newStop);
                stops.Sort();
            }
        }
    }

    public int CreateNewStop()
    {
        if (speedLevel == 2)
        {
            return Random.Range(stops[^1], stops[^1] + 31);
        }
        else if (speedLevel == 3)
        {
            return Random.Range(stops[^1], stops[^1] + 33);
        }
        else if (speedLevel == 4)
        {
            return Random.Range(stops[^1], stops[^1] + 26);
        }
        else if (speedLevel == 5)
        {
            return Random.Range(stops[^1], stops[^1] + 20);
        }
        return Random.Range(stops[^1], stops[^1] + 18);
    }

    private void ClearPassedStop()
    {
        if (stopped && !cleared)
        {
            stops.RemoveAt(0);
            cleared = true;
        }
    }

    private void Arrive()
    {
        if (stops.Count != 0)
        {
            if (floor >= stops[0])
            {
                StopCoroutine(coroutine);
                stopped = true;
                moving = false;
                floor = stops[0];
                ClearPassedStop();
            }
        }
    }

    private void StopCounter()
    {
        if (stopped)
        {
            stopTimeCounter -= Time.deltaTime;
            if (stopTimeCounter <= 0 && stops.Count > 0)
            {
                stopped = false;
                stopTimeCounter = stopTime;
                cleared = false;
            }
        }
    }

    private void Speed()
    {
        if (floor >= 1000 && speedLevel == 4)
        {
            speed = 5;
            speedLevel++;
        }
        else if (floor >= 500 && speedLevel == 3)
        {
            speed = 4;
            speedLevel++;
        }
        else if (floor >= 200 && speedLevel == 2)
        {
            speed = 3;
            speedLevel++;
        }
        else if (floor >= 100 && speedLevel == 1)
        {
            speed = 2;
            speedLevel++;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetSpeedLevel()
    {
        return speedLevel;
    }

    public int GetFloor()
    {
        return floor;
    }

    public bool Stopped()
    {
        return stopped;
    }

    public bool IsMoving()
    {
        return moving;
    }
}
