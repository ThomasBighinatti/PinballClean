using System;
using System.Collections;
using UnityEngine;

public class BumperNormal : MonoBehaviour
{
    private BumperVisuals visuals;
    
    [SerializeField] private GameObject pfScorePopup;

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
        
        if (pfScorePopup != null)
        {
            Vector3 spawnPos = other.contacts[0].point;
            spawnPos.y += 0.5f;
            spawnPos.z = -1.5f;
            
            GameObject popup = Instantiate(pfScorePopup, spawnPos, Quaternion.identity);
            
            ScorePopup scoreScript = popup.GetComponent<ScorePopup>();
            if (scoreScript != null)
            {
                // couleur de ce bumper
                Color bumperColor = GetComponent<Renderer>().material.color;
                scoreScript.Setup(score, bumperColor);
            }
        }
        
        if (visuals != null)
        {
            visuals.ActiverAnimation();
        }
    }
}