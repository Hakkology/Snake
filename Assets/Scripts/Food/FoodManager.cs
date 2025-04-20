using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public Snake snakeRef;
    public GameObject foodPrefab;
    public int poolSize = 3;
    public BoxCollider2D spawnArea;

    private List<Food> foodPool = new List<Food>();
    private int foodLeft;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(foodPrefab);
            obj.SetActive(false);
            Food food = obj.GetComponent<Food>();
            food.Initialize(this, spawnArea);
            foodPool.Add(food);
        }

        SpawnFoods();
    }

    public void OnFoodEaten(Food food)
    {
        food.gameObject.SetActive(false);
        foodLeft--;

        if (foodLeft <= 0)
        {
            SpawnFoods();
        }
    }

    private void SpawnFoods()
    {
        foodLeft = poolSize;

        foreach (Food food in foodPool)
        {
            food.RandomizePosition(snakeRef.GetSnakeSegments()); // yılan segmentleri verilir
            food.gameObject.SetActive(true);
        }
    }
}
