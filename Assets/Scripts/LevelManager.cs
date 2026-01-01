using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelGoal goal;

    public static float timer = 0f;
    public bool isLevelActive = true;
    [SerializeField] private PauseManager pauseManager;

    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    void Update()
    {
        if (!isLevelActive) return;

        timer += Time.deltaTime;

        switch (goal.goalType)
        {
            case LevelGoal.GoalType.Score:
                if (ScoreManager.score >= goal.targetScore)
                {
                    CompleteLevel();
                }
                break;

            case LevelGoal.GoalType.SurviveTime:
                if (timer >= goal.surviveDuration)
                {
                    CompleteLevel();
                }
                break;

            case LevelGoal.GoalType.ReachTrigger:
                break;
        }
    }

    public void TriggerReached(string triggerId)
    {
        if (goal.goalType == LevelGoal.GoalType.ReachTrigger
            && triggerId == goal.triggerName)
        {
            CompleteLevel();
        }
    }

    public bool CompleteLevel()
    {
        isLevelActive = false;
        goal.goalCompleted = true;
        Time.timeScale = 0f;
        pauseManager.LevelCompleteScreen();
        return true;
    }

    private void Start()
    {
        timer = 0;
        ScoreManager.score = 0;
    }
    
}
