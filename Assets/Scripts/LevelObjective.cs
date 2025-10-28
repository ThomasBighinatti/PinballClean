using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObjective : MonoBehaviour
{
    [SerializeField] public GameManager GameManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("caca");
            GameManager.GoNextLevel();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
