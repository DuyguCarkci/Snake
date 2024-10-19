using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab; 
    public BoxCollider2D gridArea; 

    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        Vector2 spawnPosition = GetRandomPositionWithinCollider();
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector2 GetRandomPositionWithinCollider()
    {
        Bounds bounds = gridArea.bounds;

        float xPos = Random.Range(bounds.min.x, bounds.max.x);
        float yPos = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(xPos, yPos);
    }
}
