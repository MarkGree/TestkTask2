using UnityEngine;


public class Player : Entity
{
    [field: SerializeField] public PlayerWaypointsMove WaypointsMove { get; private set; }

    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }


    public override void ActivateBehavior()
    {
    }

    public override void DeactivateBehavior()
    {
    }
}
