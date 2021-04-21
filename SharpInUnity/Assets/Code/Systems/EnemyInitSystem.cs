using System.Collections.Generic;
using  System.Threading.Tasks;
using Code.Components;
using Code.DataCode;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.VFX;

namespace Code.Systems
{
    /// <summary>
    /// EnemyInitSystem система создания сущностей противников
    /// </summary>
    public sealed class EnemyInitSystem : IEcsRunSystem
    {
        private ShotTrainingButton startButton;
        private Transform[] waypoints;
        //private List<Transform> spawners;
        private EcsWorld _world = new EcsWorld();

        
        public void Run()
        {
            if (startButton.isInteract)
            {
                CreateSimpleTargetEntity();
                
                startButton.isInteract = false;
            }
        }
        
        /// <summary>
        /// CreateSimpleTargetEntity метод создания и инстанса сущности Поражаемой Цели
        /// </summary>
        private void CreateSimpleTargetEntity()
        {
            var target = _world
                .NewEntity();

            target.Get<EnemyComponent>();
            
            ref var targetComponent = ref target.Get<TargetComponent>();
            ref var movableComponent = ref target.Get<MovableComponent>();

            targetComponent.waypoints = GetTargetWaypoints(waypoints);

            var targetPrefab = TargetData.LoadFromAssets("SimpleTarget");
            var targetSpawner = waypoints[Random.Range(0, waypoints.Length)];
            var spawnedTarget = GameObject.Instantiate(targetPrefab.targetPrefab,
                targetSpawner.position, Quaternion.identity);
            movableComponent.moveSpeed = targetPrefab.moveSpeed;
        }

        /// <summary>
        /// GetTargetWaypoins метод (в дальнейшем) для реализации Поражаемой ДВИЖУЩЕЙСЯ Цели
        /// Движения между 2+ точками маршрута
        /// </summary>
        /// <param name="waypoints">Все точки всех целей</param>
        /// <returns></returns>
        private List<Transform> GetTargetWaypoints(Transform[] waypoints)
        {
            var result = new List<Transform>();
            for (int i = 0; i < 2; i++)
            {
                result.Add(waypoints[Random.Range(0, waypoints.Length - 1)]);
            }
            return result;
        }
    }
}    