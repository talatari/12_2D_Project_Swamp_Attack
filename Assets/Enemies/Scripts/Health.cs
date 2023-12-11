using System;
using UnityEngine;

namespace Enemies
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 20;
    
        private int _currentHealth;
        private int _minHealth = 0;

        public event Action EnemyDestroy;
        public event Action<int, int> HealthChanged;

        public int MaxHealth => _maxHealth;
        public int CurrentHealth => _currentHealth;
    
        private void Awake() => 
            _currentHealth = _maxHealth;

        private void Start() => 
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        
        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);
        
            if (_currentHealth <= _minHealth)
                EnemyDestroy?.Invoke();
        
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}