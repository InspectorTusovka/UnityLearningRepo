using UnityEngine;

namespace Code.Components
    {
        public sealed class ShotTrainingButton : InteractComponent
        {
            public ViewComponent viewComponent;
            private bool _canInteract = false; 
     
            //Обработка возможности провзаимодействовать с объектом
            protected override void Update()
            {
                if(Input.GetKeyDown(KeyCode.E) && _canInteract) Interact();
            }

            /// <summary>
            /// Interact перегруженный метод
            /// Внедряет в EnemyInitSystem переменную-флаг для начала инициализации метода CreateSimpleTargetEntity
            /// </summary>
            public override void Interact()
            {
                isInteract = true;
            }

            //Если игрок в области нажатия кнопки
            private void OnTriggerEnter(Collider other)
            {
                if (other.CompareTag("Player"))
                {
                    viewComponent.ScreenMessage = "Нажмите E, чтобы начать тренировку стрельбы";
                    _canInteract = true;
                }
            }

            //Если игрок выходит из области нажатия кнопки
            private void OnTriggerExit(Collider other)
            {
                if (other.CompareTag("Player"))
                {
                    viewComponent.ScreenMessage = "";
                    _canInteract = false;
                }
            }
        }
    }    