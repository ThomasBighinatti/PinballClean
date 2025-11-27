using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static int score;
    [SerializeField] private TextMeshProUGUI text;
    
    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        text.text = "Score : " + score.ToString();
    }
}
