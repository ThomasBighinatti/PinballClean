using System;
using System.Collections;
using UnityEngine;

public class BumperNormal : MonoBehaviour
{
    private BumperVisuals visuals;
    
    [SerializeField] private GameObject scorePopup;

    private void Start()
    {
        visuals = GetComponent<BumperVisuals>();
    }

    public float strength = 1;
    [SerializeField] private int score = 10;
    
    void OnCollisionEnter(Collision other)
    {
        Vector3 ballDirection = other.relativeVelocity;
        Vector3 normal = -other.contacts[0].normal;
        //normalisation pour eviter vitesse exponentielle
        Vector3 direction = Vector3.Reflect(ballDirection, normal).normalized;
        
        other.rigidbody.AddForce(direction * strength, ForceMode.Impulse);
        
        ScoreManager.instance.AddScore(score);
        
        if (score > 0 && LevelManager.instance != null && LevelManager.instance.goal.goalType == LevelGoal.GoalType.Score) //si bumper donne pas 0 de score + type de score
        {
            if (scorePopup != null)
            {
                Vector3 spawnPos = other.contacts[0].point + Vector3.up * 0.5f;
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
        
        if (visuals != null)
        {
            visuals.ActiverAnimation();
        }
    }
}