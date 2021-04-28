using System;
using System.Collections;
using System.Collections.Generic;
using Code.CodeExtensions;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    public class HealthStatusSystem :MonoBehaviour, IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<PlayerComponent, InputEventComponent> playerFilter = null;
        private ViewComponent _viewComponent;

        private int _pressCounter = 1;
        private int healthAct = 10;
        
        public void Init()
        {
            foreach (var i in playerFilter)
            {
                var playerComponent =  playerFilter.Get1(i);

                _viewComponent.HealthBarFill = playerComponent.health / 100;
            }
        }
        
        public void Run()
        {
            foreach (var i in playerFilter)
            {
                 var playerComponent =  playerFilter.Get1(i);
                 var inputComponent =  playerFilter.Get2(i);

                 if (inputComponent.isHarrasTest && _pressCounter % 2 == 0)
                 {
                     RegenHealth(healthAct);
                     _pressCounter++;
                 }
                 
                 else if (inputComponent.isHarrasTest && _pressCounter % 2 != 0)
                 {
                     ReduceHealth(healthAct);
                     _pressCounter++;
                 }
            }   
            
            
        }

        private void ReduceHealth(float damage)
        {
            _viewComponent.HealthBarFill -= damage / 100;
        }

        private void RegenHealth(float regen)
        {
            _viewComponent.HealthBarFill += (regen/ 100);
        }
    }
    public delegate void HealthChange();
}