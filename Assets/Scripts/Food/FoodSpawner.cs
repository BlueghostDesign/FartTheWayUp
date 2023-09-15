using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<GameObject> foods = new();

    private List<int> foodTypes = new();

    private float spawnTime;

    private float countTime;

    private Vector3 spawnPosition;

    private Vector3 spawnScale;

    private int currFoodNum;


    private void Start()
    {
        spawnPosition = new Vector3(7.52f, -6f, 0);
        spawnScale = new Vector3(1, 1, 1);
        spawnTime = 6;
        // Initialize the food list to set appearing possibilities of each type of food.
        for (int i = 0; i < 44; i++)
        {
            foodTypes.Add(1);
            foodTypes.Add(2);
        }
        for (int i = 0; i < 8; i++)
        {
            foodTypes.Add(3);
        }
        for (int i = 0; i < 4; i++)
        {
            foodTypes.Add(4);
        }
    }

    private void Update()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        countTime += Time.deltaTime;
        // Spawn a new food every 6 seconds.
        if (countTime >= spawnTime)
        {
            int index = RandomFoodIndex();
            GameObject food = Instantiate(foods[index], spawnPosition, Quaternion.identity, GameObject.Find("Food").transform);
            food.transform.localScale = spawnScale;
            countTime = 0;
            currFoodNum++;
            // Game over if a new food is spawned while the food bar is full.
            if (currFoodNum > 6)
            {
                GameManager.GameOver();
            }
        }
    }

    private int RandomFoodIndex()
    {
        int typeIndex = Random.Range(0, foodTypes.Count);
        // Type 1 food will make the fart loud.
        if (foodTypes[typeIndex] == 1)
        {
            // Delete the food type of the recent spawned food from the list to increase the spawn possibility of foods with other types.
            foodTypes.RemoveAt(typeIndex);
            return Random.Range(0, 4);
        }
        // Type 2 food will make the fart stinky.
        else if (foodTypes[typeIndex] == 2)
        {
            foodTypes.RemoveAt(typeIndex);
            return Random.Range(4, 8);
        }
        // Type 3 food is rainbow candy.
        else if (foodTypes[typeIndex] == 3)
        {
            foodTypes.RemoveAt(typeIndex);
            return 8;
        }
        // Type 4 food is pill.
        foodTypes.RemoveAt(typeIndex);
        return 9;
    }

    public void AddFoodType(int type)
    {
        foodTypes.Add(type);
    }

    public void Ate()
    {
        // Decrease the amount of food in the food bar if one of them got eaten.
        currFoodNum -= 1;
    }
}
