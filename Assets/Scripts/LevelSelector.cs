using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    private void Start()
    {

    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
    public void LoadLevel1()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(2);
    }

    public void LoadLevel3()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(3);
    }

    public void LoadLevel4()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(4);
    }

    public void LoadLevel5()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(5);
    }

    public void LoadLevel6()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(6);
    }

    public void LoadLevelSelector()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(7);
    }
}
