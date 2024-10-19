using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public Collider2D gridArea; // Yiyecek nesnelerinin konumlandýrýlacaðý alan
    public GameObject foodPrefab; // Yiyecek prefabý için referans
    private Snake snake;

    private void Awake()
    {
        snake = FindObjectOfType<Snake>(); // Yýlaný bul
        if (gridArea == null)
        {
            Debug.LogError("gridArea deðiþkeni atanmadý! Lütfen Inspector'dan atayýn.");
        }
    }

    private void Start()
    {
        RandomizePosition(); // Oyunun baþýnda ilk yiyeceði oluþtur
    }

    public void RandomizePosition()
    {
        if (gridArea == null)
        {
            Debug.LogError("gridArea atanmadý! RandomizePosition çalýþmadý.");
            return; // gridArea atanmadýysa çýk
        }

        Bounds bounds = gridArea.bounds;
        Vector2 randomPosition;

        do
        {
            // Yiyecek için rastgele bir konum oluþtur
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            randomPosition = new Vector2(Mathf.RoundToInt(x), Mathf.RoundToInt(y));
        }
        while (snake.Occupies((int)randomPosition.x, (int)randomPosition.y)); // Yýlanýn konumunu kontrol et

        // Yiyecek prefabý varsa, instantiate et
        if (foodPrefab != null)
        {
            Instantiate(foodPrefab, randomPosition, Quaternion.identity);
            Debug.Log("Yeni yiyecek oluþturuldu: " + randomPosition); // Yeni yiyecek için log
        }
        else
        {
            Debug.LogError("foodPrefab atanmadý! Lütfen Inspector'dan atayýn.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Yýlan yiyecek nesnesine çarptýðýnda mevcut yiyeceði yok et
        if (other.CompareTag("Player"))
        {
            Debug.Log("Yemek yendikten sonra yok ediliyor: " + gameObject.name);
            Destroy(gameObject); // Mevcut yiyeceði yok et
            RandomizePosition(); // Yeni yiyecek konumu belirle
        }
    }
}
