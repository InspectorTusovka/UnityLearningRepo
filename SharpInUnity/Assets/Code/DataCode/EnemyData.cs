using System;
using UnityEngine;

    namespace Code.DataCode
    {
        /// <summary>
        /// EnemyData базовый класс для даты противников
        /// </summary>
        public class EnemyData : ScriptableObject
        {
            public GameObject targetPrefab;
            public float moveSpeed;
            public float hp;

            /// <summary>
            /// DeathRattle виртуальный метод вызывается при уничтожении противника
            /// </summary>
            public virtual void DeathRattle()
            {
                Debug.Log(targetPrefab.name);
            }
        }
    }    
