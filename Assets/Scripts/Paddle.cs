using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] HingeJoint hingeJoint;
    
    [Header("Controles")]
    [SerializeField] KeyCode key = KeyCode.Space;
    [SerializeField] KeyCode alternativeKey = KeyCode.None;

    [Header("Positions")]
    [SerializeField] float targetPosition = 75f;
    [SerializeField] float originPosition;
    

    JointSpring jointSpring;
    
    void Start()
    {
        jointSpring = hingeJoint.spring;
    }

    void Update()
    {
        if (Input.GetKey(key) || Input.GetKey(alternativeKey))
        {
            jointSpring.targetPosition = targetPosition;
        }
        else
        {
            jointSpring.targetPosition = originPosition;
        }

        hingeJoint.spring = jointSpring;
    }   
}