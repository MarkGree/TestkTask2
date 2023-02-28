using UnityEngine;


public class PlayerWaypointsMove : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private LevelWaypoints waypoints;

    private int currentIdx;

    public void MoveToNext()
    {
        currentIdx++;
        Vector3 targetMovePoint = waypoints.GetPoint(currentIdx);
        movement.FollowAt(targetMovePoint);
    }
}
