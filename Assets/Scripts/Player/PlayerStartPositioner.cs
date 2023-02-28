using UnityEngine;


public class PlayerStartPositioner : MonoBehaviour
{
    [SerializeField] private LevelWaypoints waypoints;
    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        playerTransform.position = waypoints.GetPoint(0);
    }
}
