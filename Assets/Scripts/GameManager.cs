using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int life = 4;
    [SerializeField] GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI ballsLeft;
    [SerializeField] private PauseManager pauseManager;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        life--;
        SpawnBall();
    }

    public void LoseBall()
    {
        life = life - 1;
        ballsLeft.text = "Balls left : " + life;
        CheckGameOver();
    }

    public void CheckGameOver()
    {
        if (life <= 0)
        {
            pauseManager.GameOverScreen();
        }
        else
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        Instantiate(prefab, spawnPoint.position, Quaternion.identity, transform);
    }
    
    public void QuitGame()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }
}


