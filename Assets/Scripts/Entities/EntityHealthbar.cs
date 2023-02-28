using UnityEngine;


public class EntityHealthbar : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private Progressbars.Progressbar progressbar;

    private void Awake()
    {
        entity.OnDamageE.AddListener(OnDamage);
        UpdateHealthbar();
    }

    private void OnDamage(int damage)
    {
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        progressbar.SetValue((float)entity.Health / (float)entity.MaxHealth);
    }
}
