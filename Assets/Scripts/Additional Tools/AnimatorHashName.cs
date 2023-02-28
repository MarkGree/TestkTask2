using UnityEngine;

[CreateAssetMenu(menuName = "Animator Hash Name")]
public class AnimatorHashName : ScriptableObject
{
    [SerializeField] private string animName;
    [SerializeField] private int hash;


    public int Hash => hash;

    private void OnValidate()
    {
        hash = Animator.StringToHash(animName);
    }
}
