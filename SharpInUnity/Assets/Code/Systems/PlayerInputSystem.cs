using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    /// <summary>
    /// PlayerInputSystem система считывающая ввод пользователя
    /// Внедряется в системы MoveSystem, ShotSystem
    /// </summary>
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        EcsFilter<InputEventComponent> inputEventsFilter = null;

        public void Run()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var rotation_y = Input.GetAxis("Mouse X");
            var rotation_x = -Input.GetAxis("Mouse Y");

            var isShooting = Input.GetMouseButtonDown(0);
            var isJump = Input.GetKeyDown(KeyCode.Space);

            foreach (var i in inputEventsFilter)
            {
                ref var inputEvent = ref inputEventsFilter.Get1(i);
                

                inputEvent.isShooting = isShooting;
                inputEvent.isJump = isJump;
                
                inputEvent.vertical = vertical;
                inputEvent.horizontal = horizontal;
                inputEvent.mouseRotationX = rotation_y;
                inputEvent.mouseRotationY = rotation_x;
            }
        }
    }
}