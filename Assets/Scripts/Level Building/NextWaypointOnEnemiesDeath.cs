using UnityEngine;
using UnityEngine.Events;

public class NextWaypointOnEnemiesDeath : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private UnityEvent additionalAction;

    private int deaths;

    private void Awake()
    {
        foreach (var e in enemies)
            e.OnDieE.AddListener(IncrementDeaths);
    }

    private void IncrementDeaths()
    {
        deaths++;

        if (deaths >= enemies.Length)
        {
            Player.Instance.WaypointsMove.MoveToNext();
            additionalAction.Invoke();
        }
    }
}
