using UnityEngine;

namespace Code.DataCode
{
    [CreateAssetMenu(menuName = "Create bonus")]
    public class BonusData : ScriptableObject
    {
        public GameObject bonusPrefab;
        public int BonusId;
    }
}