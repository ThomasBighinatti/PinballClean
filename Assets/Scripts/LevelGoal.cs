using System;
using TMPro;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goal;
    [SerializeField] private TextMeshProUGUI timeSurvived;
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
            goal.text = "Time to survive : " + surviveDuration.ToString();
            timeSurvived.text = "Time survived : " + Mathf.Round(LevelManager.timer).ToString();
        }
        else if (goalType == GoalType.ReachTrigger)
        {
            goal.text = "Reach the purple trigger";
        }
        else if (goalType == GoalType.Score)
        {
            goal.text = "Targer score : " + targetScore.ToString();
        }
    }
}

    
