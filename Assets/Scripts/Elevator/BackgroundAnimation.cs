using UnityEngine;

public class Background : MonoBehaviour
{
    private Material material;

    private Vector2 movement;

    private Vector2 speed;

    private Elevator elevator;

    private float currentSpeed;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        elevator = GetComponentInParent<Elevator>();
        currentSpeed = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (elevator.IsMoving() && currentSpeed != elevator.GetSpeed())
        {
            speed.y = elevator.GetSpeed();
            movement += speed * Time.deltaTime;
            material.mainTextureOffset = movement;
        }
    }
}
