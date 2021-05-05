using System.Collections.Generic;
using Code.CodeExtentions;
using Code.Data;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class BonusInitialize : IInitialize
    {
        private BonusData _bonus;
        public List<GameObject> bonuses;
        public void BonusInit(BonusData data)
        {
            _bonus = data;
        }
        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                var randomSpawn = new Vector2(Random.Range(0, 11), Random.Range(0, 11));
                bonuses.Add(GameObject.Instantiate(_bonus.bonusPrefab, randomSpawn, Quaternion.identity, null));    
            }
        }
    }
}