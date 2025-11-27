using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObjective : MonoBehaviour
{
    [SerializeField] public GameManager GameManager;
    public LevelManager levelManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelManager.CompleteLevel();
        }
    }
}
