using UnityEngine;
using UnityEngine.Events;

public class PlayerEnterTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnEnter.Invoke();
    }
}
