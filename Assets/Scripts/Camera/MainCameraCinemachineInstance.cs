using Cinemachine;
using UnityEngine;


public class MainCameraCinemachineInstance : MonoBehaviour
{
    [field: SerializeField] public CinemachineVirtualCamera CinemachineVirtualCamera { get; private set; }

    public static MainCameraCinemachineInstance Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
