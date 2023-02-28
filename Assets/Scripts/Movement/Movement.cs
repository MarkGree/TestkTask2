using UnityEngine;


public abstract class Movement : MonoBehaviour
{
    public abstract bool IsMoving { get; }

    public abstract void FollowAt(Vector3 point);
    public abstract void Stop();
}
