using UnityEngine;

    namespace Code.DataCode
    {
        /// <summary>
        /// InitData дата игрока и ally-сущностей
        /// </summary>
        [CreateAssetMenu(menuName = "Initialize", order = 1)]
        public sealed class InitData : ScriptableObject
        {
            public GameObject Prefab;
            public float defaultSpeed = 3f;
            public float defaultJumpPower = 3f;

            /// <summary>
            /// LoadFromAssets статический метод доступа к нужной дате
            /// </summary>
            /// <param name="reqDataName">Имя запрашиваемой даты</param>
            /// <returns></returns>
            public static InitData LoadFromAssets(string reqDataName) 
            {
                var result = Resources.Load($"Data/{reqDataName}") as InitData;
                return result;
            }
        }
    }