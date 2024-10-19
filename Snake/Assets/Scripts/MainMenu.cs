using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class MainMenu : MonoBehaviour
{
    // "Play" butonu için çaðrýlacak fonksiyon
    public void PlayGame()
    {
        // Burada sahne 1'i yükleyeceðiz (ana oyun sahnesi)
        // Sahne index numaranýz neyse onu kullanýn veya sahne adýný da kullanabilirsiniz.
        SceneManager.LoadScene(1); // Eðer sahneniz sahne index 1'deyse bu çalýþacaktýr
        // Alternatif olarak sahne adýný þu þekilde yükleyebilirsiniz:
        // SceneManager.LoadScene("GameScene"); // "GameScene" sizin sahnenizin adý olmalýdýr
    }

    // "Quit" butonu için çaðrýlacak fonksiyon
    public void QuitGame()
    {
        // Uygulamadan çýkýþ
        Debug.Log("Oyun kapatýldý!"); // Bu sadece editörde çalýþýr, der
        Application.Quit();
    }
}