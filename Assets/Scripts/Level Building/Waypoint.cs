using TMPro;
using UnityEditor;
using UnityEngine;


[ExecuteAlways]
public class Waypoint : MonoBehaviour
{
    [SerializeField] private TextMeshPro waypointIndexText;

    private void Update()
    {
        transform.LookAt(SceneView.lastActiveSceneView.camera.transform);
    }

    public void SetIndex(int index)
    {
        waypointIndexText.text = index.ToString();
    }
}
