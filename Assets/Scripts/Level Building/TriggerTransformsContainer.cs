using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerTransformsContainer : MonoBehaviour
{
    [SerializeField] private LayerMask lm; 
    [SerializeField] private string[] reactTags;

    private HashSet<Transform> transforms = new HashSet<Transform>();
    private HashSet<Collider> colliders = new HashSet<Collider>();

    public HashSet<Transform> Transforms => transforms;
    public event Action OnChangeA = () => { };

    public List<Transform> d_Transforms = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (!LayerMaskE.IsInLayer(lm, other.gameObject.layer)) return;

        bool isTagMatch = false;
        
        foreach (var t in reactTags)
        {
            if (other.CompareTag(t))
            {
                isTagMatch = true;
                break;
            }
        }


        if (isTagMatch && !colliders.Contains(other))
        {
            colliders.Add(other);
            transforms.Add(other.transform);

            other.GetComponent<OnDisableEvent>().OnDisableA += OnColliderDisabled;
            d_Transforms.Add(other.transform);
            
            OnChangeA.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (colliders.Contains(other))
        {
            colliders.Remove(other);
            transforms.Remove(other.transform);

            d_Transforms.Remove(other.transform);

            if (other.TryGetComponent(out OnDisableEvent disableEvent))
                disableEvent.OnDisableA -= OnColliderDisabled;

            OnChangeA.Invoke();
        }
    }

    private void OnColliderDisabled(OnDisableEvent disableEvent)
    {
        var collider = disableEvent.GetComponent<Collider>();

        if (colliders.Contains(collider))
        {
            colliders.Remove(collider);
            transforms.Remove(disableEvent.transform);

            OnChangeA.Invoke();
        }

        disableEvent.OnDisableA -= OnColliderDisabled;
    }
}
