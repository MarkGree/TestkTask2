using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
