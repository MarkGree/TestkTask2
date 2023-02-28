using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelWaypoints : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints;

    private void Awake()
    {
        foreach (var wp in waypoints)
            wp.gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        for (int i = 0; i < waypoints.Count; i++)
            waypoints[i].SetIndex(i);
    }

    public Vector3 GetPoint(int index)
    {
        return waypoints[index].transform.position;
    }
}
