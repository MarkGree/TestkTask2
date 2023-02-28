using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class Pool<T> : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private int initCount;

    private Queue<T> poolQueue = new Queue<T>();

    private void Awake()
    {
        InitSpawn();
    }

    private void InitSpawn()
    {
        GameObject obj;
        T component;

        for (int i = 0; i < initCount; i++)
        {
            obj = Instantiate(prefab, container);
            component = obj.GetComponent<T>();

            obj.SetActive(false);
            (component as IPoolable).SetPool(this);
            poolQueue.Enqueue(component);
        }
    }

    public T Get()
    {
        T instance;

        if (poolQueue.Count > 0)
        {
            instance = poolQueue.Dequeue();
        }
        else
        {
            instance = CreateNewInstance();
        }

        return instance;
    }

    public void Put(T instance)
    {
        poolQueue.Enqueue(instance);
    }

    private T CreateNewInstance()
    {
        GameObject obj = Instantiate(prefab, container);
        T component = obj.GetComponent<T>();

        obj.SetActive(false);
        (component as IPoolable).SetPool(this);

        return obj.GetComponent<T>();
    }
}
