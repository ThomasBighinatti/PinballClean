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
        if (GameOver())
        {
            SpawnBall();
        }
        ballsLeft.text = "Balls left : " + life;
    }

    public bool GameOver()
    {
        if (life <= 0)
        {
            return false;
        }

        return true;
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


