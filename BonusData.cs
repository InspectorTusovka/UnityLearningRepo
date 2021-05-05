using Code.Controllers;
using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(menuName = "Data/BonusData")]
    public sealed class BonusData : ScriptableObject
    {
        public int Id;
        public GameObject bonusPrefab;
    }
}