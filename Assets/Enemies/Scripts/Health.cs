using System;
using Players;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Player))]
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 200;
    
        private Player _player;
        private int _currentHealth;
        private int _minHealth = 0;

        public event Action PlayerDestroy;
        public event Action<int, int> HealthChanged;

        public int MaxHealth => _maxHealth;
        public int CurrentHealth => _currentHealth;
    
        private void Awake()
        {
            _player = GetComponent<Player>();
            // _player.PlayerHealthed += OnCollectedAidKit;
            _player.PlayerTakeDamage += OnTakeDamage;
        
            _currentHealth = _maxHealth;
        }

        private void Start() => 
            HealthChanged?.Invoke(_currentHealth, _maxHealth);

        private void OnDestroy()
        {
            // _player.PlayerHealthed -= OnCollectedAidKit;
            _player.PlayerTakeDamage -= OnTakeDamage;
        }

        // private void OnCollectedAidKit(int health)
        // {
        //     _currentHealth = Mathf.Clamp(_currentHealth += health, _minHealth, _maxHealth);
        //
        //     HealthChanged?.Invoke(_currentHealth, _maxHealth);
        // }
    
        private void OnTakeDamage(int damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);
        
            if (_currentHealth <= _minHealth)
                PlayerDestroy?.Invoke();
        
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}