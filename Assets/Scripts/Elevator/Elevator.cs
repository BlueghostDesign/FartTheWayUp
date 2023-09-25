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

    private int goldCollected;

    private int itemNumber;

    public int passengers;

    public int effectedPassengers;


    private void Awake()
    {
        floor = 0;
        speed = 1;
        speedLevel = 1;
        goldCollected = 0;
        itemNumber = 0;
        passengers = 0;
        effectedPassengers = 0;
        stopped = true;
        moving = false;
        cleared = false;
        stopTime = 3;
        // Add the initial stop for the elevator at the ground floor.
        stops.Add(0);
        stopTimeCounter = stopTime;
        coroutine = WaitAndCount();
    }

    private void Update()
    {
        AddNewStop();
        AllEffected();
        ItemUsed();
        Speed();
        MoveUp();
        Arrive();
        StopCounter();
    }

    private void MoveUp()
    {
        // Moves the elevator up if the elevator is currently stopped.
        // This process only runs once everytime the elevator stops.
        if (!stopped && !moving)
        {
            StartCoroutine(coroutine);
            moving = true;
        }
    }

    // Increase the current floor level of the elevator as the elevator moves up.
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
        // Ensure that there are always three upcoming stops for the elevator.
        if (stops.Count < 3)
        {
            int newStop = CreateNewStop();
            // If the new random stop is not already added, add the new stop.
            if (!stops.Contains(newStop))
            {
                stops.Add(newStop);
                // Sort the stops in increasing order.
                stops.Sort();
            }
        }
    }

    // Create a random stop for the elevator that associates with the speed of the elevator.
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
        // New random stop if the elevator speed is 1.
        return Random.Range(stops[^1], stops[^1] + 18);
    }

    private void ClearPassedStop()
    {
        // When the elevator stops, remove this floor from the stops.
        // This process only runs once everytime the elevator stops.
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
                // Wait for the NPCs to get on and get off.
                StopCoroutine(coroutine);
                stopped = true;
                moving = false;
                // Make sure the floor level is exactly the floor level of this stop when the elevator stops.
                floor = stops[0];
                ClearPassedStop();
            }
        }
    }

    // Let the elevator stops for 3 seconds to give NPCs time to get on and get off.
    private void StopCounter()
    {
        if (stopped)
        {
            stopTimeCounter -= Time.deltaTime;
            // Elevator starts moving after 3 seconds.
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

    // Reset item used if all NPCs are effected.
    private void AllEffected()
    {
        if (effectedPassengers >= passengers)
        {
            UseItem(0);
            effectedPassengers = 0;
        }
    }

    private void ItemUsed()
    {
        // Instant stop of the elevator according to the item used.
        if (itemNumber == 5)
        {
            StopCoroutine(coroutine);
            stopped = true;
            moving = false;
            // Stop for 5 seconds.
            stopTimeCounter = 5;
            // Reset item used.
            UseItem(0);
        }
    }

    public void PassengerOn()
    {
        passengers++;
    }

    public void PassengerOff()
    {
        passengers--;
    }

    public void PassengerEffected()
    {
        effectedPassengers++;
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

    public void GoldCollected()
    {
        goldCollected++;
    }

    public int GetGoldCollected()
    {
        return goldCollected;
    }

    public void UseItem(int item)
    {
        itemNumber = item;
    }

    public int GetItemUsed()
    {
        return itemNumber;
    }
}
