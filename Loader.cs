using Code.CodeExtensions;
using Code.Components;
using Code.Systems;
using UnityEngine;
using Leopotam.Ecs;

namespace Code 
{
    /// <summary>
    /// Loader  точка начала выполнения программы
    /// </summary>
    public sealed class Loader : MonoBehaviour
    {
        public Transform playerStartPoint;
        public WeaponController weaponController;
        public ShotTrainingButton startButton;
        public Transform[] waypoints;
        public SpawnerContainer spawnerContainer;

        EcsWorld _world;
        EcsSystems _systems;
        
        private void Start()
        {
            _world = new EcsWorld(); // Инициализация окружения _world
            _systems = new EcsSystems(_world); // Инициализация систем окружения _systems

            //Добавление систем к инициализации в окружении
            _systems
                .Add(new GameInitSystem())
                .Add(new EnemyInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new MoveSystem())
                .Add(new CameraSystem())
                .Add(new ShotSystem())
                .Add(new BonusInitSystem())
                
                //Внедрение зависимостей со сцены во все системы 
                //Отлов зависимостей внутри систем => ECSFilter<T>, where T [anyAllowed]Component
                .Inject(playerStartPoint)
                .Inject(weaponController)
                .Inject(startButton)
                .Inject(waypoints)
                .Inject(spawnerContainer)
            
                /*
                .Inject(levelSpawners)*/;

            
            //Инициализация систем
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null) _systems.Destroy();

            if (_world != null) _world.Destroy();
        }
    }
}