using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    /// <summary>
    /// ShotSystem система реализующая механику выстрела
    /// </summary>
    public sealed class ShotSystem : IEcsRunSystem
    {
        private EcsFilter<InputEventComponent, CameraComponent> playerInputEventFilter = null;
        private EcsFilter<EnemyComponent> enemyFilter = null;
        WeaponControllerComponent _weaponController;

        public void Run()
        {
            PlayerShot();
        }

        /// <summary>
        /// PlayerShot метод механики выстрела игрока из оружия
        /// </summary>
        private void PlayerShot()
        {
            foreach (var i in playerInputEventFilter)
            {
                ref var playerInputEvent = ref playerInputEventFilter.Get1(i);
                ref var playerCamera = ref playerInputEventFilter.Get2(i);

                if (playerInputEvent.isShooting && _weaponController.currentWeapon.bulletCount > 0)
                {
                    _weaponController.Shoot(_weaponController.currentWeapon);
                    Vector3 rayOrigin = playerCamera.camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            
                    RaycastHit hit;
                    if (Physics.Raycast(rayOrigin, playerCamera.camera.transform.forward, out hit, Mathf.Infinity))
                    {
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            hit.collider.GetComponent<DamageHandler>().TakeDamage(_weaponController.currentWeapon.damage);
                        }        
                    }
                }
            }
        }
    }
}