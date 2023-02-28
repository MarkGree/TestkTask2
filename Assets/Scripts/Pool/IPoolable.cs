using UnityEngine;


public interface IPoolable
{
    public void SetPool<T>(Pool<T> pool);
}
