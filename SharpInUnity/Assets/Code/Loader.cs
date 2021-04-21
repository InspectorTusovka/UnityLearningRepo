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
        public WeaponControllerComponent weaponController;
        public ShotTrainingButton startButton;
        public Transform[] waypoints;

        EcsWorld _world;
        EcsSystems systems;
        
        private void Start()
        {
            _world = new EcsWorld(); // Инициализация окружения _world
            systems = new EcsSystems(_world); // Инициализация систем окружения _systems

            //Добавление систем к инициализации в окружении
            systems
                .Add(new GameInitSystem())
                .Add(new EnemyInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new MoveSystem())
                .Add(new CameraSystem())
                .Add(new ShotSystem())
                
                //Внедрение зависимостей со сцены во все системы 
                //Отлов зависимостей внутри систем => ECSFilter<T>, where T [anyAllowed]Component
                .Inject(playerStartPoint)
                .Inject(weaponController)
                .Inject(startButton)
                .Inject(waypoints)
            
                /*
                .Inject(levelSpawners)*/;

            
            //Инициализация систем
            systems.Init();
        }

        private void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            if (systems != null) systems.Destroy();

            if (_world != null) _world.Destroy();
        }
    }
}