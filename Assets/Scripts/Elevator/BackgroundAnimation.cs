using UnityEngine;

public class Background : MonoBehaviour
{
    private Material material;

    private Vector2 movement;

    private Vector2 speed;

    private Elevator elevator;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        elevator = GetComponentInParent<Elevator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Play the background animation at the speed of the elevator while the elevator is moving up.
        if (elevator.IsMoving())
        {
            speed.y = elevator.GetSpeed();
            movement += speed * Time.deltaTime;
            material.mainTextureOffset = movement;
        }
    }
}
