using System.Collections;
using UnityEngine;


public class PlayerLookAtNearest : MonoBehaviour
{
    [SerializeField] private TriggerTransformsContainer trigger;
    [SerializeField] private Transform forwardTransform;

    // Можно убрать зависимость от триггера, добавив отдельный скрипт для
    // установки ближайшего трансформа, но я намеренно упростил это

    private Transform nearestTransform;

    private void Awake()
    {
        trigger.OnChangeA += UpdateNearest;
    }

    private void UpdateNearest()
    {
        var transforms = trigger.Transforms;

        if (transforms.Count > 0)
        {
            nearestTransform = Tools.FindNeaerestTransform.Find(transform.position, transforms);

            MainCameraCinemachineInstance.Instance.CinemachineVirtualCamera.LookAt = nearestTransform;
        }
        else
        {
            nearestTransform = null;

            MainCameraCinemachineInstance.Instance.CinemachineVirtualCamera.LookAt = forwardTransform;
        }
    }
}
