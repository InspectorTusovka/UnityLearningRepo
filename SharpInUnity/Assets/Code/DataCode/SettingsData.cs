using UnityEngine;


    namespace Code.DataCode
    {
        /// <summary>
        /// SettingsData дата настроек игры
        /// </summary>
        [CreateAssetMenu(menuName = "Settings", order = 1)]
        public sealed class SettingsData : ScriptableObject
        {
            //InputSettings
            public float lookLimit = 60f;
            public float mouseSense = 2f;
        
            //LevelSettings

            public static SettingsData LoadFromAssets(string reqDataName)
            {
                var result = Resources.Load($"Data/{reqDataName}") as SettingsData; 
                return result;
            }
        }
    }
