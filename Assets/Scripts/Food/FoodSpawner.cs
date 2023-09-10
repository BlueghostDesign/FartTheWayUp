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

    public int currFoodNum;


    private void Start()
    {
        spawnPosition = new Vector3(7.52f, -6f, 0);
        spawnScale = new Vector3(1, 1, 1);
        spawnTime = 6;
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
        if (countTime >= spawnTime)
        {
            int index = RandomFoodIndex();
            GameObject food = Instantiate(foods[index], spawnPosition, Quaternion.identity, GameObject.Find("Food").transform);
            food.transform.localScale = spawnScale;
            countTime = 0;
            currFoodNum++;
            if (currFoodNum > 6)
            {
                GameManager.GameOver();
            }
        }
    }

    private int RandomFoodIndex()
    {
        int typeIndex = Random.Range(0, foodTypes.Count);
        if (foodTypes[typeIndex] == 1)
        {
            foodTypes.RemoveAt(typeIndex);
            return Random.Range(0, 4);
        }
        else if (foodTypes[typeIndex] == 2)
        {
            foodTypes.RemoveAt(typeIndex);
            return Random.Range(4, 8);
        }
        else if (foodTypes[typeIndex] == 3)
        {
            foodTypes.RemoveAt(typeIndex);
            return 8;
        }
        foodTypes.RemoveAt(typeIndex);
        return 9;
    }

    public void AddFoodType(int type)
    {
        foodTypes.Add(type);
    }
}
