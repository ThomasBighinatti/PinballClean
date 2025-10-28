
using UnityEngine;
using UnityEngine.Events;
public class EventController : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnterEvent;
    [SerializeField] UnityEvent onTriggerExitEvent;
    [SerializeField] UnityEvent onCollisionEnterEvent;

    void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent.Invoke();

    }
    void OnTriggerExit(Collider other)
    {
        onTriggerEnterEvent.Invoke();

    }
    void OnCollisionEnter(Collision other)
    {
        onTriggerEnterEvent.Invoke();

    }
    
}