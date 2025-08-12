using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject GamePauseUI;
    private bool isPaused = false;
    public GameObject gameOverUI;

    private Controls controls;

    void Awake()
    {
        controls = new Controls();
        controls.PS4.Pause.performed += ctx => Pausetrigger();
    }
    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable(); 
    void Pausetrigger()
    {
        if(gameOverUI.activeSelf) return;
            if (isPaused) ResumeGame();
            else PauseGame();
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
    public void MainMenuPauseButton()
    {
        GamePauseUI.SetActive(false);
        
        DashBoardUI.instance.DashBoard();

    }
  
}
