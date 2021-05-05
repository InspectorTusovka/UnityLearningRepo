using Code.CodeExtentions;
using Code.Data;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class PlayerInitialize : IInitialize
    {
        private PlayerData _player;
        public void PlayerInit(PlayerData data)
        {
            _player = data;
        }
        public void Initialize()
        {
            GameObject.Instantiate(_player.playerPrefab, Vector2.zero, Quaternion.identity, null);
        }
        
        public Transform PlayerRoot => _player.playerPrefab.transform;
    }
}