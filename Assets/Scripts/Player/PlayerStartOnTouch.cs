using UnityEngine;


public class PlayerStartOnTouch : MonoBehaviour
{
    [SerializeField] private PlayerWaypointsMove waypointsMove;

    private bool hasWorked;

    private void Update()
    {
        if (hasWorked) return;

        if (Input.GetMouseButtonDown(0))
        {
            hasWorked = true;
            waypointsMove.MoveToNext();
        }
    }
}
