using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodManager manager;
    private BoxCollider2D spawnArea;

    public void Initialize(FoodManager foodManager, BoxCollider2D area)
    {
        manager = foodManager;
        spawnArea = area;
    }

public void RandomizePosition(List<Transform> snakeSegments)
{
    Bounds bounds = spawnArea.bounds;
    Vector3 newPos;
    int maxAttempts = 100;
    int attempts = 0;

    do
    {
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        newPos = new Vector3(x, y, 0);
        attempts++;
    }
    while (IsOnSnake(newPos, snakeSegments) && attempts < maxAttempts);

    transform.position = newPos;
}

    private bool IsOnSnake(Vector3 pos, List<Transform> snakeSegments)
    {
        foreach (var segment in snakeSegments)
        {
            if (segment.position == pos)
                return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Snake"))
        {
            manager.OnFoodEaten(this); 
        }
    }
}