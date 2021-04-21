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
                .Get<PlayerComponent>();
            player
                .Get<InputEventComponent>();

            ref var movableComponent = ref player.Get<MovableComponent>();
            ref var cameraComponent = ref player.Get<CameraComponent>();

            var playerInitData = InitData.LoadFromAssets("PlayerInitData");
            
            var spawnedPlayerPrefab = GameObject
                .Instantiate(playerInitData.Prefab, playerStartPoint.position, Quaternion.identity);

            cameraComponent.camera = spawnedPlayerPrefab.GetComponentInChildren<Camera>();

            movableComponent.moveSpeed = playerInitData.defaultSpeed;
            movableComponent.jumpPower = playerInitData.defaultJumpPower;
            movableComponent.transform = spawnedPlayerPrefab.transform;
            movableComponent.characterController = spawnedPlayerPrefab.GetComponent<CharacterController>();

            var settings = _world
                .NewEntity();
            ref var settingsComponent = ref settings.Get<SettingsComponent>();

            var settingsInitData = SettingsData.LoadFromAssets("GameSettings");

            settingsComponent.lookLimit = settingsInitData.lookLimit;
            settingsComponent.mouseSense = settingsInitData.mouseSense;
        }
    }
}