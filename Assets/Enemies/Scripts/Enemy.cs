using UnityEngine;
using Players;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _coins = 2;
        [SerializeField] private PlayerDied _playerDied;

        private Health _health;
        private Player _player;

        public Player Player => _player;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _player = FindObjectOfType<Player>();
        }

        private void OnEnable()
        {
            _player.PlayerDie += OnPlayerDie;
            _health.EnemyDie += OnEnemyDie;
        }
        
        private void OnEnemyDie()
        {
            _player.GiveReward(_coins);
            
            _player.PlayerDie -= OnPlayerDie;
            _health.EnemyDie -= OnEnemyDie;
            
            Destroy(gameObject);
        }
        
        private void OnPlayerDie() =>
            _playerDied.Transit();

        public void TakeDamage(int damage) => 
            _health.TakeDamage(damage);
    }
}