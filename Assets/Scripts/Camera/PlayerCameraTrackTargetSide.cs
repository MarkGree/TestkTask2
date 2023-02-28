using Cinemachine;
using UnityEngine;


public class PlayerCameraTrackTargetSide : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCamera;
    [SerializeField] private float composerScreenXMax;

    private Cinemachine3rdPersonFollow thirdPersonFollow;
    private CinemachineComposer composer;

    private void Awake()
    {
        thirdPersonFollow = vCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        composer = vCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    private void Update()
    {
        if (vCamera.LookAt != null)
        {
            Vector2 targetPlanePosition = ToPlanePosition(vCamera.LookAt.position);
            Vector2 planeCameraPosition = ToPlanePosition(vCamera.transform.position);
            Vector2 planeCameraForward = ToPlanePosition(vCamera.transform.forward);

            bool isTargetRightSide = Vector2.SignedAngle(planeCameraForward, (targetPlanePosition - planeCameraPosition).normalized) >= 0f;

            if (isTargetRightSide)
            {
                thirdPersonFollow.CameraSide = Mathf.Lerp(thirdPersonFollow.CameraSide, 1f, 0.1f);
                composer.m_ScreenX = Mathf.Lerp(composer.m_ScreenX, 0.5f + -composerScreenXMax, 0.1f);
            }
            else
            {
                thirdPersonFollow.CameraSide = Mathf.Lerp(thirdPersonFollow.CameraSide, -1f, 0.1f);
                composer.m_ScreenX = Mathf.Lerp(composer.m_ScreenX, 0.5f + composerScreenXMax, 0.1f);
            }
        }
    }

    // Я забил делать новый скрипт для одной этой функции, но в реальном проекте её бы сделал
    private Vector2 ToPlanePosition(Vector3 pos)
    {
        return new Vector2(pos.x, pos.z);
    }
}
