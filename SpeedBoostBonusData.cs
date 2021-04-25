using UnityEngine;

namespace Code.DataCode
{
    public class SpeedBoostBonusData : BonusData
    {
        public float speedBoost;
        
        public static SpeedBoostBonusData LoadFromAssets(string reqData)
        {
            var result = Resources.Load($"Data/BonusesData/{reqData}") as SpeedBoostBonusData;
            return result;
        }
    }
}