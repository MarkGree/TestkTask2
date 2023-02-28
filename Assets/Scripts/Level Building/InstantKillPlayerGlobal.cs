using UnityEngine;


public class InstantKillPlayerGlobal : MonoBehaviour
{
    public void Kill()
    {
        Player.Instance.Damage(Player.Instance.Health);
        Debug.Log("Kill Player");
    }
}
