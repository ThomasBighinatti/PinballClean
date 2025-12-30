using System;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float strength = 10f;
    [SerializeField] private int score = 10;
    
    private BumperVisuals visualScript;

    private void Start()
    {
        visualScript = GetComponent<BumperVisuals>();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(transform.position);
        Vector3 a = transform.position;
        Vector3 b = other.transform.position;
        Vector3 direction;
        direction = b - a;
        direction = direction.normalized;

        other.rigidbody.AddForce(direction * strength, ForceMode.Impulse);
        
        ScoreManager.instance.AddScore(score);
        
        if (visualScript != null)
        {
            visualScript.ActiverAnimation();
        }
    }
}