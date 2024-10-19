using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public Collider2D gridArea; // Yiyecek nesnelerinin konumland�r�laca�� alan
    public GameObject foodPrefab; // Yiyecek prefab� i�in referans
    private Snake snake;

    private void Awake()
    {
        snake = FindObjectOfType<Snake>(); // Y�lan� bul
        if (gridArea == null)
        {
            Debug.LogError("gridArea de�i�keni atanmad�! L�tfen Inspector'dan atay�n.");
        }
    }

    private void Start()
    {
        RandomizePosition(); // Oyunun ba��nda ilk yiyece�i olu�tur
    }

    public void RandomizePosition()
    {
        if (gridArea == null)
        {
            Debug.LogError("gridArea atanmad�! RandomizePosition �al��mad�.");
            return; // gridArea atanmad�ysa ��k
        }

        Bounds bounds = gridArea.bounds;
        Vector2 randomPosition;

        do
        {
            // Yiyecek i�in rastgele bir konum olu�tur
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            randomPosition = new Vector2(Mathf.RoundToInt(x), Mathf.RoundToInt(y));
        }
        while (snake.Occupies((int)randomPosition.x, (int)randomPosition.y)); // Y�lan�n konumunu kontrol et

        // Yiyecek prefab� varsa, instantiate et
        if (foodPrefab != null)
        {
            Instantiate(foodPrefab, randomPosition, Quaternion.identity);
            Debug.Log("Yeni yiyecek olu�turuldu: " + randomPosition); // Yeni yiyecek i�in log
        }
        else
        {
            Debug.LogError("foodPrefab atanmad�! L�tfen Inspector'dan atay�n.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Y�lan yiyecek nesnesine �arpt���nda mevcut yiyece�i yok et
        if (other.CompareTag("Player"))
        {
            Debug.Log("Yemek yendikten sonra yok ediliyor: " + gameObject.name);
            Destroy(gameObject); // Mevcut yiyece�i yok et
            RandomizePosition(); // Yeni yiyecek konumu belirle
        }
    }
}
