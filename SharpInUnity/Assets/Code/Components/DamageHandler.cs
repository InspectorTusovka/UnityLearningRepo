using Code.DataCode;
using UnityEngine;

namespace Code.Components
{
    /// <summary>
    /// DamageHandler базовый класс для всех объектов, подверженных получению урона
    /// </summary>
    public class DamageHandler : MonoBehaviour
    {
        [SerializeField] private EnemyData enemy;
        private float _healthPoints;
        
        private void Start()
        {
            _healthPoints = enemy.hp;
        }

/// <summary>
/// TakeDamage метод для обработки поступающего урона
/// </summary>
/// <param name="damage">Принятый объектом урон</param>
        public void TakeDamage(float damage)
        {
            _healthPoints -= damage;
            if(_healthPoints <= 0) Death();
        }
/// <summary>
/// Death метод который стоит, возможно, поменять на destroy+ondestroy, на след. домашке мб
/// </summary>
        private void Death()
        {
            enemy.DeathRattle();
            Destroy(gameObject);
        }
    }
}