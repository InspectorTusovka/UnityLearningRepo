using System.Collections.Generic;
using Code.DataCode;
using UnityEngine;

namespace Code.Components
{
    /// <summary>
    /// WeaponControllerComponent is Controller in MVC pattern
    /// </summary>
    public sealed class WeaponControllerComponent : MonoBehaviour
    {
        public ViewComponent weaponView;
        public List<WeaponData> weaponAll;
        [HideInInspector] public WeaponData currentWeapon;
        
        /// <summary>
        /// Пока что симпл-метод инициализации оружия
        /// Вывод количества патронов на экран через вьюшку
        /// </summary>
        private void Start()
        {
            currentWeapon = ChangeWeapon(0);
            weaponView.BulletsInfo = currentWeapon.bulletCount.ToString();
        }
        
        /// <summary>
        /// Shoot метод произведения выстрела из текущего орудия в ркуах игрока
        /// Воспроизведение звука выстрела; Уменьшение количества патронов
        /// </summary>
        /// <param name="current">Текущее оружие</param>
        public void Shoot(WeaponData current)
        {
            current.weaponSource.PlayOneShot(current.shotSound);
            current.bulletCount--;
            weaponView.BulletsInfo = current.bulletCount.ToString();
        }

        /// <summary>
        /// ChangeWeapon метод возвращающий оружие по его ID для интсанса в руках игрока
        /// </summary>
        /// <param name="id">Уникальный идентификатор оружия</param>
        /// <returns></returns>
        private WeaponData ChangeWeapon(int id)
        {
            //return default ID = 0
            var current = ScriptableObject.CreateInstance<WeaponData>();
            foreach (var weapon in weaponAll)
            {
                if (weapon.Id == 0) current = weapon;
            }

            return current;
        }
    }
}