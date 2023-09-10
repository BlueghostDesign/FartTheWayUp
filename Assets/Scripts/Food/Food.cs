using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody2D rb;

    private PlayerAnimation playerAnimation;

    private PlayerController playerController;

    private FoodSpawner foodSpawner;

    public int type;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GameObject.Find("Player").transform.GetComponent<PlayerAnimation>();
        playerController = GameObject.Find("Player").transform.GetComponent<PlayerController>();
        foodSpawner = GameObject.Find("FoodSpawner").transform.GetComponent<FoodSpawner>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(0, 1);
    }

    private void OnMouseDown()
    {
        if (!playerController.eating)
        {
            playerAnimation.SetAnimation();
            playerController.Eat(type);
            foodSpawner.currFoodNum -= 1;
            foodSpawner.AddFoodType(type);
            Destroy(gameObject);
        }
    }
}
