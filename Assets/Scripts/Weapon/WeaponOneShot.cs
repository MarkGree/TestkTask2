using UnityEngine;


public class WeaponOneShot : Weapon
{
    [SerializeField] private ProjectilesPool projectiles;
    [SerializeField] private Transform barrelPoint;
    [SerializeField] private int damage;
    [SerializeField] private string shooterIgnoreTag;

    public override void Shoot(Vector3 targetPosition)
    {
        Vector3 shootDirection = (targetPosition - barrelPoint.position).normalized;
        var projectile = projectiles.Get();
        projectile.gameObject.SetActive(true);

        projectile.transform.position = barrelPoint.position;
        projectile.Shoot(shootDirection, damage, shooterIgnoreTag);
    }
}
