using System;
using Code.Components;
using Code.DataCode;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code.CodeExtensions
{
    public sealed class AmmoBonus : Collectable
    {
        [SerializeField] private AmmoData bonus;

        public override void Collect()
        {
            var controller = FindObjectOfType<WeaponController>();
            var currentWeapon = controller.currentWeapon;

            if (currentWeapon.Id == bonus.WeaponId)
                if (currentWeapon.currentAmmunition != currentWeapon.maxAmmo)
                   currentWeapon.currentAmmunition = Mathf
                       .Clamp(currentWeapon.currentAmmunition + bonus.bulletsRefill, 0, currentWeapon.maxAmmo);
            
            controller.weaponView.BulletsInfo = $"{currentWeapon.bulletCount}/{currentWeapon.currentAmmunition}";
            
            Dispose();
        }

        public override void Dispose()
        {
            LogWarning($"Было подобрано {bonus.bulletsRefill} патронов");
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Collect();
            }
        }
    }
}