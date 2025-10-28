using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameManager.instance.LoseBall();
    }
}
