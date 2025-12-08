using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	[SerializeField] private GameObject gameOverMenu;
    public GameManager GameManager; 
    public GameObject pauseMenuUI;
    public Button pauseButton;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
	
    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(TogglePause);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause();
        }

        GameOverScreen();
    }
    
    
    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
            Debug.Log("Resume");
        }
        else
        {
            Pause();
            Debug.Log("Pause");
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }



    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
        gameOverMenu.SetActive(false);
    }

    public void GameOverScreen()
    {
        if (GameManager.GameOver() == false)
        {
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }
    
    
    
}