using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] HingeJoint hingeJoint;
    [SerializeField] KeyCode key = KeyCode.Space;
    [SerializeField] float targetPosition = 75f;
    [SerializeField] float originPosition;

    JointSpring jointSpring;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jointSpring = hingeJoint.spring;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
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
