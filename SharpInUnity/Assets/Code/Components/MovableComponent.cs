using UnityEngine;

    namespace Code.Components
    {
        public struct MovableComponent 
        {
            public Transform transform;
            public CharacterController characterController;
            public Vector2 rotation;
            public float moveSpeed;
            public float jumpPower;

            public bool isMoving;
        }
    }
