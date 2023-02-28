using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour, IDamageable
{
    [field: SerializeField] public UnityEvent OnDieE { get; private set; }
    [field: SerializeField] public UnityEvent<int> OnDamageE { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }

    private bool isAlive = true;

    public void Heal(int healValue)
    {
        Health = Mathf.Clamp(Health += healValue, 0, MaxHealth);
    }
    public void Damage(int damage)
    {
        if (isAlive)
        {
            Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
            
            OnDamageE.Invoke(damage);
            if (Health <= 0)
            {
                isAlive = false;
                OnDieE.Invoke();
                DeactivateBehavior();
            }
        }
    }

    public abstract void ActivateBehavior();
    public abstract void DeactivateBehavior();
}
