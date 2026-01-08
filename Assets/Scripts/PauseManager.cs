using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] private GameManager gameManager;
    [SerializeField, Space] private LevelManager levelManager;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] public GameObject levelCompletedMenu;
    [SerializeField, Space] private GameObject pauseMenuUI;
    [SerializeField] private Button pauseButton;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    #endregion
    
	
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
            if ((!gameOverMenu.activeSelf) && (!levelCompletedMenu.activeSelf))
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

    public void LevelCompleteScreen()
    {
            levelCompletedMenu.SetActive(true);
    }
    
    public void NextLevel()
    {
        gameManager.life = 4;
        Time.timeScale = 1f;
        levelCompletedMenu.SetActive(false);
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((n+1)%SceneManager.sceneCountInBuildSettings);
        
    }
    
    
    
}