using UnityEngine;

public class LevelGoal : MonoBehaviour
{

    public enum GoalType
    {
        Score,
        SurviveTime,
        ReachTrigger
    }
    
    public GoalType goalType;
    
    public int targetScore;
    public float surviveDuration;
    public string triggerName;

    public bool goalCompleted = false;
}
