using System;
using Code.DataCode;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code.CodeExtensions
{
    public class EndGameBonus : Collectable
    {
        [SerializeField] private EndGameBonusData gameBonusData;
        
        public override void Collect()
        {
            ++gameBonusData.collectedBonuses;
            if (gameBonusData.collectedBonuses == gameBonusData.reqBonusesCount)
            {
                var view = FindObjectOfType<ViewComponent>();

                view.ScreenMessage = "Победа! Вы собрали все бонусы!";
                Time.timeScale = 0;
            }
            
            Dispose();
        }

        public override void Dispose()
        {
            Log($"Сейчас собрано {gameBonusData.collectedBonuses} бонусов. Осталось собрать еще {gameBonusData.reqBonusesCount - gameBonusData.collectedBonuses}");
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) Collect();
        }
    }
}