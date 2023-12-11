using UnityEngine;
using Players;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _coins = 2;
        [SerializeField] private Player _player;
        
        private Health _health;

        public Player Player => _player;

        private void Awake() => 
            _health = GetComponent<Health>();

        private void OnEnable() => 
            _health.EnemyDestroy += OnDestroy;

        private void OnDisable() => 
            _health.EnemyDestroy -= OnDestroy;

        private void OnDestroy()
        {
            if (_player is not null)
            {
                _player.GiveReward(_coins);
                _player = null;
            }
                
            Destroy(gameObject);
        }

        public void TakeDamage(int damage) => 
            _health.TakeDamage(damage);
    }
}