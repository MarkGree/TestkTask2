using UnityEngine;


public class RagdollActivity : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider selfCollider;
    [SerializeField] private Rigidbody[] rigidBodies;
    [SerializeField] private Collider[] colliders;
    [SerializeField] private bool isEnabled;

    private void Awake()
    {
        if (isEnabled)
            Enable();
        else
            Disable();
    }

    public void Enable()
    {
        animator.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;

        selfCollider.enabled = false;
        foreach (var c in colliders)
        {
            c.enabled = true;
        }
        foreach (var rb in rigidBodies)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }

    public void Disable()
    {
        animator.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;

        selfCollider.enabled = true;
        foreach (var c in colliders)
        {
            c.enabled = false;
        }
        foreach (var rb in rigidBodies)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    private void OnValidate()
    {
        if (rb == null)
            gameObject.GetComponent<Rigidbody>();

        if (colliders == null || colliders.Length == 0)
            colliders = GetComponentsInChildren<Collider>(true);
        
        if (rigidBodies == null || rigidBodies.Length == 0)
            rigidBodies = GetComponentsInChildren<Rigidbody>(true);

        if (isEnabled)
            Enable();
        else
            Disable();
    }
}
