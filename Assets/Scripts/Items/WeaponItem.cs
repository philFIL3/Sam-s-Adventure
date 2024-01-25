using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon Item", menuName ="Create Weapon Item")]
public abstract class WeaponItem : Item
{
    public enum eWeaponType
    {
        SecretOfProtector,
        Shotgun,
        PlasmaSniper,
        Desolation,
        Dominion,
        BreakerOfTerror,
        MessegerOfShadow,
        FavorOfTheMoon,
        LastBreath,
        Legacy,
        Cataclysm,
        Destruction,
        Disturbance,
        JudgementBlaster,
    }

    public eWeaponType WeaponType;

    public enum eWeaponAttackType
    {
        Gun,
        Shotgun,
        Assault,
        Sniper
    }

    public eWeaponAttackType WeaponAttackType;

    public enum eWeaponFireType
    {
        Manual,
        Automatic
    }

    public eWeaponFireType weaponFireType;

    public float FireRate;
    public int WeaponDamage;
    public GameObject projectilePrefab;
    protected GameObject projectile;
    public int WeaponCost;
    public float DamageMultiplier;
    protected float time;
    public bool Shooting = false;

    public virtual IEnumerator Shoot(GameObject Arm)
    {
        yield break;    
    }

    public void StopShoot()
    {
        Shooting = false;
    }

    public void StartShoot()
    {
        Shooting = true;
    }

    protected void DamageCalculator(float dmg, GameObject projectile)
    {
        if (Random.Range(0f, 1f) <= (Player.Instance.PlayerSO.CRITRATE / 100))
            projectile.GetComponent<Projectile>().damage = dmg * (Player.Instance.PlayerSO.CRITDAMAGE / 100);
        else
            projectile.GetComponent<Projectile>().damage = dmg;
    }

    public void BuyItem()
    {
        if (UIController.Instance.Coins >= WeaponCost)
        {
            UIController.Instance.CoinsUp(-WeaponCost);
            PlayerInventoryUI.Instance.AddWeaponToInventory(this);
            Debug.Log("You have acquired " + name);
        }
    }

    public virtual void Update()
    {
        
    }
}
