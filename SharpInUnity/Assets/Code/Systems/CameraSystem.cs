using Code.Components;
using Leopotam.Ecs;
using UnityEngine;


    namespace Code.Systems
    {
        /// <summary>
        /// CameraSystem система поворота камеры согласно вводу от игрока
        /// </summary>
        public sealed class CameraSystem : IEcsRunSystem
        {
            EcsFilter<InputEventComponent, CameraComponent> cameraInputFilter = null;
            EcsFilter<SettingsComponent> settingFilter = null;
        
            public void Run()
            {
                foreach (var i in cameraInputFilter)
                {
                    ref var cameraComponent = ref cameraInputFilter.Get2(i);
                    ref var inputEvent = ref cameraInputFilter.Get1(i);
                    ref var settingsComponent = ref settingFilter.Get1(i);

                    cameraComponent.rotation.x += inputEvent.mouseRotationY * settingsComponent.mouseSense;
                    cameraComponent.rotation.x = Mathf.Clamp(cameraComponent.rotation.x, -settingsComponent.lookLimit, settingsComponent.lookLimit);
                    cameraComponent.camera.transform.localRotation = Quaternion.Euler(cameraComponent.rotation.x, 0, 0);
                }
            }
        }
    }    