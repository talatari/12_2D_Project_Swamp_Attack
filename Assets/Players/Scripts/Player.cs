using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Health), typeof(Animator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;

        private Weapon _currentWeapon;
        private Health _health;
        private Enemy _currentTarget;
        private Animator _animator;
        
        // public event Action<int> PlayerHealthed;
        public event Action<int> PlayerTakeDamage;
        public event Action<Enemy> PlayerGiveDamage;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _health.PlayerDestroy += OnDestroy;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // TODO: получить координаты клика - нужен рейкастер
                // TODO: передать в метод Shoot класса Attacker поинт таргета
            }
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