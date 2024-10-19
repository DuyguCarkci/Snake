using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab; // Yiyecek prefab'ini inspector'da atayýn
    public BoxCollider2D gridArea; // Grid alaný olarak kullanacaðýnýz 2D BoxCollider

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
        // Collider'ýn sýnýrlarýný al
        Bounds bounds = gridArea.bounds;

        // Rastgele bir x ve y pozisyonu üret, collider'ýn sýnýrlarý içinde kalsýn
        float xPos = Random.Range(bounds.min.x, bounds.max.x);
        float yPos = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(xPos, yPos);
    }
}
