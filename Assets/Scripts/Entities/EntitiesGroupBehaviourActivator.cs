using UnityEngine;


public class EntitiesGroupBehaviourActivator : MonoBehaviour
{
    [SerializeField] private Entity[] entities;

    public void Activate()
    {
        foreach (var e in entities)
            e.ActivateBehavior();
    }

    public void Deactivate()
    {
        foreach (var e in entities)
            e.DeactivateBehavior();
    }
}
