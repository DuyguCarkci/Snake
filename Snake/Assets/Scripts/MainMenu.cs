using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli

public class MainMenu : MonoBehaviour
{
    // "Play" butonu i�in �a�r�lacak fonksiyon
    public void PlayGame()
    {
        // Burada sahne 1'i y�kleyece�iz (ana oyun sahnesi)
        // Sahne index numaran�z neyse onu kullan�n veya sahne ad�n� da kullanabilirsiniz.
        SceneManager.LoadScene(1); // E�er sahneniz sahne index 1'deyse bu �al��acakt�r
        // Alternatif olarak sahne ad�n� �u �ekilde y�kleyebilirsiniz:
        // SceneManager.LoadScene("GameScene"); // "GameScene" sizin sahnenizin ad� olmal�d�r
    }

    // "Quit" butonu i�in �a�r�lacak fonksiyon
    public void QuitGame()
    {
        // Uygulamadan ��k��
        Debug.Log("Oyun kapat�ld�!"); // Bu sadece edit�rde �al���r, der
        Application.Quit();
    }
}