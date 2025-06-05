using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{

    public static GameOverUI instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        instance = this;

    }
    public void Gameover()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        // gemManager.EndScoreUpdate();
        
    }
    public void Restartgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
