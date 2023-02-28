using UnityEngine;


public class AutoRotator : MonoBehaviour
{
    [SerializeField] private Vector3 axis;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }

    private void OnValidate()
    {
        axis.Normalize();
    }
}
