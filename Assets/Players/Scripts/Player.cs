using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;

        private Weapon _currentWeapon;
        private Health _health;
        private Enemy _currentTarget;
        
        // public event Action<int> PlayerHealthed;
        public event Action<int> PlayerTakeDamage;
        public event Action<Enemy> PlayerGiveDamage;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.PlayerDestroy += OnDestroy;
        }

        private void OnDisable()
        {
            _health.PlayerDestroy -= OnDestroy;
        }

        private void OnDestroy() => 
            Destroy(gameObject);

        public void TakeDamage(int damage) => 
            PlayerTakeDamage?.Invoke(damage);

        private void OnGiveDamage() => 
            PlayerGiveDamage?.Invoke(_currentTarget);
    }
}