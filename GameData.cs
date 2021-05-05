using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(menuName = "Data/GameData")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private string playerData;
        [SerializeField] private string bonusData;

        private PlayerData _player;
        private BonusData _bonus;

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>(playerData);
                }

                return _player;
            }
        }
        
        public BonusData Bonus
        {
            get
            {
                if (_bonus == null)
                {
                    _bonus = Load<BonusData>(bonusData);
                }

                return _bonus;
            }
        }

        private T Load<T>(string reqDataName) where T : class
        {
            return Resources.Load($"Data/{reqDataName}") as T ;
        }
    }
}