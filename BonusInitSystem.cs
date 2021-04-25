using System;
using Code.CodeExtensions;
using Code.Components;
using Code.DataCode;
using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Systems
{
    public sealed class BonusInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = default;
        private SpawnerContainer _spawnerContainer;
        

        public void Init()
        {
            CreateAmmoBonus();
            for (int i = 0; i < 3; i++)
            {
                CreateEndGameBonus();
            }

            for (int i = 0; i < 2; i++)
            {
                //CreateSpeedBoostBonus();
            }
        }
        
        private void CreateAmmoBonus()
        {
            var ammoBonus = _world
                .NewEntity();

            ammoBonus.Get<BonusComponent>();

            var ammoInitData = AmmoData.LoadFromAssets("TestAmmoData");
            var spawnedAmmoBonus =
                GameObject.Instantiate(ammoInitData.bonusPrefab, GetRandomSpot(), Quaternion.identity);
        }
        private void CreateEndGameBonus()
        {
            var gameBonus = _world
                .NewEntity();

            gameBonus.Get<BonusComponent>();

            var gameBonusInitData = EndGameBonusData.LoadFromAssets("TestGameBonus");
            var spawnedGameBonus =
                GameObject.Instantiate(gameBonusInitData.bonusPrefab, GetRandomSpot(), Quaternion.identity);
        }

        private void CreateSpeedBoostBonus()
        {
            var bonus = _world
                .NewEntity();

            var bonusInitData = SpeedBoostBonusData.LoadFromAssets("TestSpeedBoost");
            var spawnedBonus = GameObject.Instantiate(bonusInitData.bonusPrefab, GetRandomSpot(), Quaternion.identity);
        }
        private Vector3 GetRandomSpot()
        {
            var posX = Random.Range(
                _spawnerContainer.ammoBonusAreaSpawn[Random.Range(0, _spawnerContainer.ammoBonusAreaSpawn.Count)].position.x
                , _spawnerContainer.ammoBonusAreaSpawn[Random.Range(0, _spawnerContainer.ammoBonusAreaSpawn.Count)].position.x);
            
            var posY = _spawnerContainer.ammoBonusAreaSpawn[0].position.y;
            
            var posZ = Random.Range(
                _spawnerContainer.ammoBonusAreaSpawn[Random.Range(0, _spawnerContainer.ammoBonusAreaSpawn.Count)].position.x
                , _spawnerContainer.ammoBonusAreaSpawn[Random.Range(0, _spawnerContainer.ammoBonusAreaSpawn.Count)].position.x);

            return new Vector3(posX, posY, posZ);
        }
    }
}