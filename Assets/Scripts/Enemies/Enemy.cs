using System.Collections;
using UnityEngine;


// Для прототипа решил не усложнять и сделал поведение в одном скрипте, без StateMachine

public class Enemy : Entity
{
    [SerializeField] private Movement movement;

    private bool isActive;

    public override void ActivateBehavior()
    {
        movement.FollowAt(Player.Instance.transform.position);
        isActive = true;

        StartCoroutine(CUpdatePlayerPosition());
    }

    public override void DeactivateBehavior()
    {
        movement.Stop();
        isActive = false;

        StopAllCoroutines();
    }

    private IEnumerator CUpdatePlayerPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (isActive)
                movement.FollowAt(Player.Instance.transform.position);
        }
    }

    private void OnValidate()
    {
        if (movement == null)
        {
            movement = gameObject.AddComponent<RigidbodyMovement>();
        }
    }
}
