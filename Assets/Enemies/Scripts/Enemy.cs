using Players;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _coins = 2;
        [SerializeField] private Player _player;
        
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.EnemyDestroy += OnDestroy;
        }

        private void OnDisable()
        {
            _health.EnemyDestroy -= OnDestroy;
        }
        
        private void OnDestroy()
        {
            // TODO: успевает проскочить как минимум 2 события 
            // TODO: в итоге награда задваивается
            _player.GiveReward(_coins);
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}