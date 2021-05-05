using Code.CodeExtentions;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class CameraController : IOnLateFrame
    {
        private readonly Transform _playerRoot;
        private readonly Transform _camera;
        private readonly Vector3 _offset;
        
        public CameraController(Transform playerRoot, Transform camera)
        {
            _playerRoot = playerRoot;
            _camera = camera;
            _offset = _camera.position - _playerRoot.position;
        }

        public void OnLateFrame(float deltaTime)
        {
            _camera.position += _offset;
        }
    }
}