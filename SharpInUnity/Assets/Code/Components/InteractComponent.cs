using UnityEngine;

namespace Code.Components
    {
        /// <summary>
        /// Базовый абстрактный класс для всех объектов взаимодействия в окружении
        /// </summary>
        public abstract class InteractComponent : MonoBehaviour
        {
            [HideInInspector] public bool isInteract;

            //Если абстракт апдейт из абстрактного класса проходит в пул задач, то это стоит фиксить - спросить на ЛК!!!
            protected abstract void Update();
            public abstract void Interact();
        }
    }    