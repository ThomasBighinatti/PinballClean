using System;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float strength = 10f;
    [SerializeField] private int score = 10;
    
    [SerializeField] private GameObject scorePopup;

    private BumperVisuals visualScript;

    private void Start()
    {
        visualScript = GetComponent<BumperVisuals>();
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 direction = (other.transform.position - transform.position).normalized;
        other.rigidbody.AddForce(direction * strength, ForceMode.Impulse);
        
        ScoreManager.instance.AddScore(score);

        if (score > 0 && LevelManager.instance != null && LevelManager.instance.goal.goalType == LevelGoal.GoalType.Score)
        {
            if (scorePopup != null)
            {
                Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
                spawnPos.z = 0f;

                GameObject popup = Instantiate(scorePopup, spawnPos, Quaternion.identity);

                ScorePopup scoreScript = popup.GetComponent<ScorePopup>();
                if (scoreScript != null)
                {
                    //couleur
                    Color bumperColor = GetComponent<Renderer>().material.color;
                    scoreScript.Setup(score, bumperColor);
                }
            }
        }

        if (visualScript != null)
        {
            visualScript.ActiverAnimation();
        }
    }
}