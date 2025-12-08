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
            if (!gameOverMenu.activeSelf)
            {
                TogglePause();
            }
        }
    }
    
    
    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
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
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        gameOverMenu.SetActive(false);
    }

    public void GameOverScreen()
    {
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
    }
    
    
    
}