using Code.CodeExtensions;
using Code.Components;
using Leopotam.Ecs;

namespace Code.Systems
{
    public delegate void HealthChange();
    public class HealthStatusSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<PlayerComponent, InputEventComponent> playerFilter = null;
        private ViewComponent _viewComponent;

        private int _pressCounter = 1;
        private int healthAct = 10;
        
        private  LowHpService _lowHp;
        private HealthChange _change;
        
        public void Init()
        {
            foreach (var i in playerFilter)
            {
                var playerComponent =  playerFilter.Get1(i);

                _viewComponent.HealthBarFill = playerComponent.health / 100;
            }
            _change = _lowHp.CrosshairColorChange;
            _change += _lowHp.MusicSpeedBoost;
        }
        
        public void Run()
        {
            foreach (var i in playerFilter)
            {
                var playerComponent = playerFilter.Get1(i);
                var inputComponent = playerFilter.Get2(i);

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

            var currentHp = _viewComponent.HealthBarFill * 100;
            if (currentHp <= 55)
            {
                _change();
            }
        }

        private void ReduceHealth(float damage)
        {
            _viewComponent.HealthBarFill -= damage / 100;
        }

        private void RegenHealth(float regen)
        {
            _viewComponent.HealthBarFill += regen/ 100;
        }
    }
}