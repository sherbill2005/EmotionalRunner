using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject GamePauseUI;
    private bool isPaused = false;
    public GameObject gameOverUI;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(gameOverUI.activeSelf) return;
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        GamePauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        isPaused = true;
        GamePauseUI.SetActive(true);
        Time.timeScale = 0f;
     }
    // public void RestartGame()
    // {
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
    public void MainMenu()
    {
        // isPaused = true;
        // // MainMenuPanel.SetActive(true);x
        // Time.timeScale = 0f;
    }
}
