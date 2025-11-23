using System;
using TMPro;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
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

    private void Start()
    {
        
    }
    void Update()
    {
        if (goalType == GoalType.SurviveTime)
        {
            text.text = "Time to survive : " + LevelManager.timer.ToString();
        }
        else if (goalType == GoalType.ReachTrigger)
        {
            text.text = "Reach the purple trigger";
        }
        else if (goalType == GoalType.Score)
        {
            text.text = "Score objective : " + targetScore.ToString();
        }
    }
}

    
