using UnityEngine;

    namespace Code.DataCode
    {
        /// <summary>
        /// WeaponData дата оружия игры
        /// </summary>
        [CreateAssetMenu(menuName = "Create weapon", order = 2)]
        public sealed class WeaponData : ScriptableObject
        {
            public int Id;
            public GameObject weaponPrefab;
            public int bulletCount;
            public AudioClip shotSound;
            public AudioSource weaponSource;
            public float damage;
        }
    }
