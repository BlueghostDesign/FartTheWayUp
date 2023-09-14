using UnityEngine;

public class ElevatorStopSFX : MonoBehaviour
{
    private AudioSource elevatorDing;

    private Elevator elevator;

    private bool notified;


    private void Awake()
    {
        elevatorDing = GetComponent<AudioSource>();
        elevator = GetComponent<Elevator>();
        notified = false;
    }

    private void Update()
    {
        if (elevator.Stopped() && !notified)
        {
            Notify();
            notified = true;
        }
        else if (elevator.IsMoving())
        {
            notified = false;
        }
    }

    public void Notify()
    {
        elevatorDing.Play();
    }
}
