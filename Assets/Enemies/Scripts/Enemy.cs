using System;
using UnityEngine;
using Players;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _coins = 2;
        [SerializeField] private PlayerDied _playerDied;
        [SerializeField] private CloseDistance _closeDistance;
        
        private Health _health;
        private Player _player;

        public Player Player => _player;

        public event Action<Enemy> EnemyDie; 
        
        private void Awake() => 
            _health = GetComponent<Health>();

        public void Init(Player player)
        {
            _player = player;
            _player.Dead += OnPlayerDead;
            _health.EnemyDie += OnEnemyDie;
        }

        public void TakeDamage(int damage) => 
            _health.TakeDamage(damage);

        private void OnEnemyDie()
        {
            _player.GiveReward(_coins);
            
            EnemyDie?.Invoke(this);
            
            _player.Dead -= OnPlayerDead;
            _health.EnemyDie -= OnEnemyDie;
            
            Destroy(gameObject);
        }

        private void OnPlayerDead()
        {
            _closeDistance.Transit();
            _playerDied.Transit();
        }
    }
}