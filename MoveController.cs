using Code.CodeExtentions;
using Code.Data;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class MoveController : IOnFrame
    {
        private Vector3 _moveDir;
        private readonly float _moveSpeed;
        private readonly InputController _controller;
        private readonly Transform _playerRoot;
        private Vector2 _move;
        
        public MoveController(InputController controller, Transform player, float speed)
        {
            _controller = controller;
            _playerRoot = player;
            _moveSpeed = speed;
        }

        public void OnFrame(float time)
        {
            _moveDir =  Vector3.up * _controller.GetInput().Vertical * _moveSpeed + Vector3.right * _controller.GetInput().Horizontal * _moveSpeed;
            _playerRoot.localPosition += _moveDir;
        }
    }
}