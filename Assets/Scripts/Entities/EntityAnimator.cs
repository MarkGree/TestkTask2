using UnityEngine;


public class EntityAnimator : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorHashName idleHashName;
    [SerializeField] private AnimatorHashName runHashName;

    private Movement movement;

    private State state;
    private enum State
    {
        Idle,
        Moving
    }

    private void Awake()
    {
        movement = entity.GetComponent<Movement>();
    }

    // Вместо проверки IsMoving можно можно сделать событие в Movement,
    // но и этого достаточно
    private void Update()
    {
        if (state == State.Idle)
        {
            if (movement.IsMoving)
            {
                state = State.Moving;
                animator.Play(runHashName.Hash);
            }
        }
        else
        if (state == State.Moving)
        {
            if (!movement.IsMoving)
            {
                state = State.Idle;
                animator.Play(idleHashName.Hash);
            }
        }
    }
}
