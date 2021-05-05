using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Code.Data
{
    [CreateAssetMenu(menuName = "Data/PlayerData")]
    public sealed class PlayerData : ScriptableObject
    {
        public float defaultSpeed = 4;
        public GameObject playerPrefab;
    }
}