using Code.Components;
using Leopotam.Ecs;

namespace Code.Systems
{
    /// <summary>
    /// WeaponInitSystem система инстанса оружия на сцену (N/A)
    /// </summary>
    public sealed class WeaponInitSystem : IEcsInitSystem, IEcsRunSystem
    {
        private WeaponControllerComponent _weaponController;
        private EcsFilter<PlayerComponent> playerComponentFilter = null;

        
        public void Init()
        {
            //Здесь нужно как-то и куда-то инстансить оружие
            //var weapon = GameObject.Instantiate(_weaponController.currentWeapon.weaponPrefab, weaponHandler.position,
              //  Quaternion.identity);

        }

        public void Run()
        {
            
        }
    }
}