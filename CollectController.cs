using System.Collections.Generic;
using Code.CodeExtentions;
using Code.Data;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class CollectController : IOnFrame
    {
        private readonly List<GameObject> _bonuses;
        private readonly GameObject _player;

        public CollectController(List<GameObject> bonuses, GameObject player)
        {
            _bonuses = bonuses;
            _player = player;
        }
        
        public void OnFrame(float deltaTime)
        {
            foreach (var bonus in _bonuses)
            {
                if ((bonus.transform.position - _player.transform.position).magnitude <= 0.25f )
                {
                    Collect(bonus);
                }
            }
        }

        private void Collect(GameObject collectableItem)
        {
            _bonuses.Remove(collectableItem);
            Debug.LogWarning("Подобран бонус!");
        }
    }
}