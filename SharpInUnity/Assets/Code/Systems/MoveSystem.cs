using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems 
{
    /// <summary>
    /// MoveSystem система реализующая движение сущностей
    /// </summary>
    public sealed class MoveSystem : IEcsRunSystem
    {
        EcsFilter<MovableComponent, InputEventComponent> playerMoveFilter = null;
        private EcsFilter<MovableComponent, TargetComponent> targetMoveFilter = null;
        EcsFilter<SettingsComponent> settingFilter = null;
        
        public void Run()
        {
            PlayerMove();
        }

        /// <summary>
        /// PlayerMove метод реализующий движение игрока согласно ввода пользователя
        /// </summary>
        private void PlayerMove()
        {
            foreach (var i in playerMoveFilter)
            {
                ref var movableComponent = ref playerMoveFilter.Get1(i);
                ref var inputComponent = ref playerMoveFilter.Get2(i);

                ref var settingsComponent = ref settingFilter.Get1(i);

                if (/*movableComponent.characterController.isGrounded*/ true)
                {
                    movableComponent.rotation.y += inputComponent.mouseRotationX * settingsComponent.mouseSense;
                    movableComponent.transform.eulerAngles = new Vector2(0, movableComponent.rotation.y);

                    var moveDirection = movableComponent.transform.forward * inputComponent.vertical + movableComponent.transform.right * inputComponent.horizontal;

                    if (inputComponent.isJump)
                    {
                        moveDirection.y = movableComponent.jumpPower;
                    }

                    moveDirection.y -= 60f * Time.deltaTime;
                    
                    movableComponent.characterController.Move(moveDirection * (Time.deltaTime * movableComponent.moveSpeed));
                }
            }
        }

        
        /// <summary>
        /// TargetMove метод движения сущности Поражаемой Движущейся Цели (N/A)
        /// </summary>
        private void TargetMove()
        {
            foreach (var i in targetMoveFilter)
            {
                ref var movableComponent = ref targetMoveFilter.Get1(i);
                ref var targetComponent = ref targetMoveFilter.Get2(i);
                
                if (targetComponent.isMoving)
                {
                            
                }
            }
        }
    }
}