using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int life = 3;
    [SerializeField] GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    
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
        Debug.Log("Lose Ball");

        life = life - 1;
        Debug.Log("lives left: " + life);
        if (GameOver())
        {
            SpawnBall();
        }
    }

    public bool GameOver()
    {
        if (life < 0)
        {
            Debug.Log("Game Over");
            return false;
        }

        return true;
    }

    void SpawnBall()
    {
        Instantiate(prefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void GoNextLevel()
    {
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((n+1)%SceneManager.sceneCountInBuildSettings);
    }
}


