using System;
using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform playerCenter;
    [SerializeField] private PlayerInput input;
    [SerializeField] private Weapon weapon;
    [SerializeField] private LayerMask attackCastTargetLM;
    [SerializeField] private float playerAirShootDistance;
    [SerializeField] private float attackDelay;

    private bool isAttackDelay;

    private void Awake()
    {
        input.OnTouch += ShootAtScreenPosition;
    }

    private void ShootAtScreenPosition(Vector3 inputScreenPosition)
    {
        if (isAttackDelay) return;


        var ray = Camera.main.ScreenPointToRay(inputScreenPosition);

        Vector3 shootPosition;
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, attackCastTargetLM))
        {
            shootPosition = hit.point;
        }
        else
        {
            shootPosition = playerCenter.transform.position + ray.direction * playerAirShootDistance;
        }

        StartCoroutine(CAttackDelay());

        weapon.Shoot(shootPosition);
    }

    private IEnumerator CAttackDelay()
    {
        isAttackDelay = true;
        yield return new WaitForSeconds(attackDelay);
        isAttackDelay = false;
    }
}
