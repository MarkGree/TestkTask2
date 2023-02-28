using System.Collections;
using UnityEngine;


public class Projectile : MonoBehaviour, IPoolable
{
    [SerializeField] private float speed;
    [SerializeField] private float autoRemoveDelay;

    private Vector3 moveVector;
    private ProjectilesPool pool;
    private int damage;
    private string ignoreTag;
    
    private void FixedUpdate()
    {
        transform.position += moveVector * Time.fixedDeltaTime;
    }

    // Можно все параметры снаряда устанавливать при стрельбе в самом оружии,
    // но и такого метода этого достаточно для этого прототипа
    public void Shoot(Vector3 direction, int damage, string ignoreWithTag)
    {
        this.damage = damage;
        this.ignoreTag = ignoreWithTag;
        moveVector = direction * speed;
        StartCoroutine(CAutoRemove());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && !other.CompareTag(this.ignoreTag))
        {
            damageable.Damage(this.damage);
            StopAllCoroutines();
            Deactivate();
        }
    }
    
    private IEnumerator CAutoRemove()
    {
        yield return new WaitForSeconds(autoRemoveDelay);
        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        pool.Put(this);
    }

    public void SetPool<T>(Pool<T> pool)
    {
        this.pool = pool as ProjectilesPool;
    }
}
