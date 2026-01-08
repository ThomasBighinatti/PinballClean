using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public int life = 4;
    [SerializeField] GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI ballsLeft;
    [SerializeField] private PauseManager pauseManager;

    [Header("personnalisation couleurs balle")]
    [SerializeField] private Material ballMaterial; 
    [SerializeField] private Material trailMaterial; 
    
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
        GameObject newBall = Instantiate(prefab, spawnPoint.position, Quaternion.identity, transform);
        
        //changement balle
        if (ballMaterial != null)
        {
            Renderer ballRenderer = newBall.GetComponent<Renderer>();
            if (ballRenderer != null)
            {
                ballRenderer.material = ballMaterial;
            }
        }

        //changement trail
        if (trailMaterial != null)
        {
            TrailRenderer trail = newBall.GetComponentInChildren<TrailRenderer>();
            
            if (trail != null)
            {
                trail.material = trailMaterial;
            }
        }
    }
    
    public void QuitGame()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }
}