using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector3> OnTouch = (position) => { };

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTouch.Invoke(Input.mousePosition);
        }
    }
}
