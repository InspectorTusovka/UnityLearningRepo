using UnityEngine;
namespace Code.DataCode
{
    [CreateAssetMenu(menuName = "Create bonus/Create endGame bonus")]
    public class EndGameBonusData : BonusData
    {
        public int collectedBonuses;
        public int reqBonusesCount;
        
        
        public static EndGameBonusData LoadFromAssets(string reqData)
        {
            var result = Resources.Load($"Data/BonusesData/{reqData}") as EndGameBonusData;
            return result;
        }
    }
}