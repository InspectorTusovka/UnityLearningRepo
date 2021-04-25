using System;
using Code.CodeExtensions;
using UnityEngine;

namespace Code.DataCode
{
    [CreateAssetMenu(menuName = "Create bonus/Create ammo")]
    public class AmmoData : BonusData
    {
        public int WeaponId;
        public int bulletsRefill;
        
        public static AmmoData LoadFromAssets(string reqData)
        {
            var result = Resources.Load($"Data/BonusesData/{reqData}") as AmmoData;
            return result;
        }
    }
}