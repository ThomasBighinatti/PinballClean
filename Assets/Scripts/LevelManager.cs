using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelGoal goal;

    private float timer = 0f;
    private bool isLevelActive = true;


    void Update()
    {
        if (!isLevelActive) return;

        timer += Time.deltaTime;

        switch (goal.goalType)
        {
            case LevelGoal.GoalType.Score:
                if (ScoreManager.score >= goal.targetScore)
                {
                    Debug.Log("asterion");
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

    public void CompleteLevel()
    {
        isLevelActive = false;
        goal.goalCompleted = true;
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((n+1)%SceneManager.sceneCountInBuildSettings);
    }
}
