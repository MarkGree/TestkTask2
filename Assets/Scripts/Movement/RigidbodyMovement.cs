using System.Drawing;
using UnityEngine;


public class RigidbodyMovement : Movement
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private bool isOnlyHorizontalMovement;

    private Vector3 targetPoint;
    private Vector3 velocity;
    private bool isMoving;
    public override bool IsMoving => isMoving;

    public override void FollowAt(Vector3 point)
    {
        this.targetPoint = point;
        isMoving = true;
    }

    public override void Stop()
    {
        velocity = Vector3.zero;
        isMoving = false;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            if (isOnlyHorizontalMovement)
            {
                Vector3 moveDistance = new Vector3(targetPoint.x - transform.position.x, 0f, targetPoint.z - transform.position.z);
                velocity = moveDistance.normalized * speed;
            }
            else
            {
                velocity = (targetPoint - transform.position).normalized;
            }

            rb.velocity = velocity * speed * Time.fixedDeltaTime;
        }
    }
}
