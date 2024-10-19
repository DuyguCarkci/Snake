using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab; // Yiyecek prefab'ini inspector'da atay�n
    public BoxCollider2D gridArea; // Grid alan� olarak kullanaca��n�z 2D BoxCollider

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
        // Collider'�n s�n�rlar�n� al
        Bounds bounds = gridArea.bounds;

        // Rastgele bir x ve y pozisyonu �ret, collider'�n s�n�rlar� i�inde kals�n
        float xPos = Random.Range(bounds.min.x, bounds.max.x);
        float yPos = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(xPos, yPos);
    }
}
