using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    public Transform segmentPrefab;
    public Vector2Int direction = Vector2Int.right;
    public float speed = 20f;
    public float speedMultiplier = 1f;
    public int initialSize = 4;
    public bool moveThroughWalls = false;

    public AudioSource audioSource;  // Ses kayna�� (AudioSource)
    public AudioClip eatSound;       // Yemek yeme sesi (AudioClip)
    public FoodSpawner foodSpawner;  // FoodSpawner referans�
    public ScoreManager scoreManager; // ScoreManager referans�

    private readonly List<Transform> segments = new List<Transform>();
    private Vector2Int input;
    private float nextUpdate;

    private void Start()
    {
        ResetState();
        audioSource = GetComponent<AudioSource>();  // AudioSource bile�enini al
    }

    private void Update()
    {
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = Vector2Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = Vector2Int.down;
            }
        }
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = Vector2Int.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = Vector2Int.left;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Time.time < nextUpdate)
        {
            return;
        }

        if (input != Vector2Int.zero)
        {
            direction = input;
        }

        // Segmentleri hareket ettir
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);

        nextUpdate = Time.time + (1f / (speed * speedMultiplier));

        // Y�lan�n kendi kuyru�una �arp�p �arpmad���n� kontrol et
        CheckSelfCollision();
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void ResetState()
    {
        direction = Vector2Int.right;
        transform.position = Vector3.zero;

        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);

        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }
    }

    public bool Occupies(int x, int y)
    {
        foreach (Transform segment in segments)
        {
            if (Mathf.RoundToInt(segment.position.x) == x &&
                Mathf.RoundToInt(segment.position.y) == y)
            {
                return true; // Y�lan bu konumu kapl�yor
            }
        }
        return false; // Y�lan bu konumu kaplam�yor
    }

    // Y�lan�n kendisine �arp�p �arpmad���n� kontrol et
    private void CheckSelfCollision()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            if (segments[i].position == transform.position)
            {
                // Y�lan kendi kuyru�una �arpt�, skoru s�f�rla ve yeniden ba�lat
                if (scoreManager != null)
                {
                    scoreManager.ResetScore();  // Skoru s�f�rla
                }
                ResetState();  // Y�lan� ba�a d�nd�r
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Grow();
            audioSource.PlayOneShot(eatSound);  // Yemek yeme sesini �al
            Destroy(other.gameObject);  // Yiyece�i yok et

            // Yeni yiyecek spawn et
            if (foodSpawner != null)
            {
                foodSpawner.SpawnFood();
            }

            // Skoru art�r
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(); // Skoru art�r
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            ResetState();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            if (moveThroughWalls)
            {
                Traverse(other.transform);
            }
            else
            {
                // Skoru s�f�rla
                if (scoreManager != null)
                {
                    scoreManager.ResetScore();  // Skoru s�f�rla
                }
                ResetState();
            }
        }
    }

    private void Traverse(Transform wall)
    {
        Vector3 position = transform.position;

        if (direction.x != 0f)
        {
            position.x = Mathf.RoundToInt(-wall.position.x + direction.x);
        }
        else if (direction.y != 0f)
        {
            position.y = Mathf.RoundToInt(-wall.position.y + direction.y);
        }

        transform.position = position;
    }
}
