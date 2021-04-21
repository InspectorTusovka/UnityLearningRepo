using UnityEngine;

    namespace Code.DataCode
    {
        /// <summary>
        /// TargetData дата Поражаемой Цели (ShotTrainingButton)
        /// </summary>
        [CreateAssetMenu(menuName = "Create simple target")]
        public sealed class TargetData : EnemyData
        {
            /// <summary>
            /// LoadFromAssets статический метод доступа к нужной дате
            /// </summary>
            /// <param name="reqDataName">Имя запрашиваемой даты</param>
            /// <returns></returns>
            public static TargetData LoadFromAssets(string reqDataName)
            {
                return Resources.Load($"Data/EnemyData/SimpleTargetData/{reqDataName}") as TargetData;
            }

            /// <summary>
            /// DeathRattle перегруженный метод вызываемый при уничтожении объекта
            /// </summary>
            public override void DeathRattle()
            {
                base.DeathRattle();
                Debug.Log(nameof(TargetData));
            }
        }
    }
