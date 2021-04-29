using System;
using Code.CodeExtensions;
using Code.Components;
using Code.DataCode;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    /// <summary>
    /// GameInitSystem основная система иницилизации игры и создания обязательных сущностей сцены 
    /// </summary>
    public sealed class GameInitSystem : IEcsInitSystem
    {
        private Transform playerStartPoint;
 
        EcsWorld _world = null;
        
        void IEcsInitSystem.Init()
        {
            CreatePlayerEntity();
        }
        
        /// <summary>
        /// CreatePlayerEntity метод создания сущности игрока и настроек
        /// </summary>
        private void CreatePlayerEntity()
        {
            var player = _world
                .NewEntity();
            player
                .Get<InputEventComponent>();
            
            ref var playerComponent = ref player.Get<PlayerComponent>();
            ref var movableComponent = ref player.Get<MovableComponent>();
            ref var cameraComponent = ref player.Get<CameraComponent>();

            var playerInitData = InitExtensions.LoadData<InitData>("AllyData","PlayerInitData");
            
            var spawnedPlayerPrefab = GameObject
                .Instantiate(playerInitData.Prefab, playerStartPoint.position, Quaternion.identity);

            cameraComponent.camera = spawnedPlayerPrefab.GetComponentInChildren<Camera>();
            
            
            
            try
            {
                if (playerInitData.defaultSpeed <= 0)
                    throw new UncorrectDataException();
            }
            catch (UncorrectDataException e)
            {
                Debug.LogError(e.Message);
            }
            finally
            {
                movableComponent.moveSpeed = playerInitData.defaultSpeed;
            }
            
            movableComponent.jumpPower = playerInitData.defaultJumpPower;
            movableComponent.transform = spawnedPlayerPrefab.transform;
            movableComponent.characterController = spawnedPlayerPrefab.GetComponent<CharacterController>();

            playerComponent.health = playerInitData.defaultHealth;
            
            var settings = _world
                .NewEntity();
            ref var settingsComponent = ref settings.Get<SettingsComponent>();

            var settingsInitData = InitExtensions.LoadData<SettingsData>("SettingsData", "GameSettings");

            settingsComponent.lookLimit = settingsInitData.lookLimit;
            settingsComponent.mouseSense = settingsInitData.mouseSense;
        }
    }
}