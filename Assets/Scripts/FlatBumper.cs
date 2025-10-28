using UnityEngine;

public class BumperNormal : MonoBehaviour
{
    public float strength = 1;
    [SerializeField] private int score = 10;
    void OnCollisionEnter(Collision other)
    {
        Vector3 ballDirection = other.relativeVelocity;
        Vector3 normal = -other.contacts[0].normal;
        Vector3 direction = Vector3.Reflect(ballDirection, normal);
        
        Debug.DrawRay(other.contacts[0].point, direction, Color.red,10);
        Debug.DrawRay(other.contacts[0].point, normal, Color.blue,10);
        
        
        other.rigidbody.AddForce(direction * strength);
        
        ScoreManager.instance.AddScore(score);
    }
}
