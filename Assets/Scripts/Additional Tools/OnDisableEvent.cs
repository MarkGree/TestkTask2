using System;
using UnityEngine;


public class OnDisableEvent : MonoBehaviour
{
    public event Action<OnDisableEvent> OnDisableA = (self) => { };

    private void OnDisable()
    {
        OnDisableA.Invoke(this);
    }
}
